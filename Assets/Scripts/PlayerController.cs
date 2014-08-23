using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	private float moveSpeed = 10f;
	private float jumpLength = 1000f;

    public string player;
    private string horizontal = string.Empty;
    private string vertical = string.Empty;
    private string jump = string.Empty;

	private bool grounded = true;
	private bool jumping = false;
	private float jumpEndTime = -1f;
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
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
	    PlayerInput();          
	}

	void PlayerInput()
	{
		float hAxis = Input.GetAxis(horizontal);
		float vAxis = Input.GetAxis(vertical);
		bool jumpTrig = Input.GetButton(jump);

		Vector2 move = new Vector2(hAxis*moveSpeed, vAxis*moveSpeed);

		if (move.magnitude > 0.5)
		{
			var angle = Mathf.Atan2(move.y, move.x)*Mathf.Rad2Deg;

			transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
		}
		anim.SetFloat("Speed", move.magnitude);

		if (jumping)
		{
			if (jumpEndTime < Time.timeSinceLevelLoad)
				jumping = false;
		}
		else if (jumpTrig)
		{

			jumping = true;
			jumpEndTime = Time.timeSinceLevelLoad + jumpLength;
		}

		anim.SetBool("Jump", jumping);

		if (!jumping)
			anim.SetBool("Fall", !grounded);

		rigidbody2D.velocity = move;
	}
}
