using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float initX;
	public float initY;
	private float moveSpeed = 10f;
	public float jumpLength = 1f;

    public string player;
    private string horizontal = string.Empty;
    private string vertical = string.Empty;
    private string jump = string.Empty;

	private bool grounded = true;
	private bool jumping = false;
	private float jumpEndTime = 0f;
	private bool dead = false;

	public Transform groundCheck;
	private float groundRadius = 0.02f;
	public LayerMask whatIsGround;

	private Animator anim;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
	    horizontal = "Horizontal" + player;
	    vertical = "Vertical" + player;
	    jump = "Jump" + player;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetButton("Reset"))
		{
			Application.LoadLevel("ViktorsMain");
		}
		if (!dead)
		{
			PlayerInput();
		}
	}

	void PlayerInput()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		float hAxis = Input.GetAxis(horizontal);
		float vAxis = Input.GetAxis(vertical);
		bool jumpTrig = Input.GetButton(jump);

		Vector2 move = new Vector2(hAxis*moveSpeed, vAxis*moveSpeed);

		if (Input.GetButton(horizontal) || Input.GetButton(vertical))
		{
			var angle = Mathf.Atan2(move.y, move.x)*Mathf.Rad2Deg;

			transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
		}
		anim.SetFloat("Speed", move.magnitude);

		if (jumping && jumpEndTime < Time.timeSinceLevelLoad)
		{
			jumping = false;
			if (!grounded) dead = true;
		}

		if (jumpTrig && !jumping && !dead)
		{
			jumping = true;
			jumpEndTime = Time.timeSinceLevelLoad + jumpLength;
		}

		anim.SetBool("Jump", jumping);

		if (!jumping && !grounded)
		{
			anim.SetBool("Fall", true);
			dead = true;
		}
		rigidbody2D.velocity = dead ? Vector2.zero : move;
	}
}
