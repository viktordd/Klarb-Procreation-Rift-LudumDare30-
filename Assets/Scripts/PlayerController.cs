using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float moveSpeed = 3f;

    public string player;
    private string horizontal = string.Empty;
    private string vertical = string.Empty;
	private string jump = string.Empty;

	public bool Jumping { get { return jumping; } }
	private bool grounded = true;
	private bool jumping = false;
	private bool dead = false;

	public Transform groundCheck;
	private float groundRadius = 0.01f;
	public LayerMask whatIsGround;

	private Animator anim;
	private AudioSource[] audio;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		audio = GetComponents<AudioSource>();
		spriteRenderer = GetComponent<SpriteRenderer>();

		SwitchHelper.Switch(anim, player);

		horizontal = "Horizontal" + player;
	    vertical = "Vertical" + player;
		jump = "Jump" + player;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
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
		bool jumpTrig = Input.GetButtonDown(jump);

		Vector2 move = new Vector2(hAxis*moveSpeed, vAxis*moveSpeed);
		move = Vector2.ClampMagnitude(move, moveSpeed);
		anim.SetFloat("Speed", move.magnitude);

		if (Input.GetButton(horizontal) || Input.GetButton(vertical))
		{
			var angle = Mathf.Atan2(move.y, move.x)*Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
		}

		if (jumpTrig && grounded && !dead)
		{
			jumping = true;
			anim.SetBool("Jump", true);
			audio[0].Play();
		}

		if (!jumping && !grounded)
		{
			StartFallSequence(move);
			return;
		}
		rigidbody2D.velocity = dead ? Vector2.ClampMagnitude(move, moveSpeed/3f) : move;
	}

	// Called from at the end of Jump of animation.
	public void EndJump()
	{
		jumping = false;
		anim.SetBool("Jump", false);
		if (!grounded)
		{
			StartFallSequence(rigidbody2D.velocity);
		}
	}

	private void StartFallSequence(Vector2 move)
	{
		dead = true;
		anim.SetBool("Fall", true);
		audio[0].Play();
		Destroy(collider2D);
		spriteRenderer.sortingLayerName = "Falling Player";
		rigidbody2D.velocity = Vector2.ClampMagnitude(move, moveSpeed/3f);
	}

	// Called from at the end of Jump of animation.
	public void EndFall()
	{
		Destroy(gameObject);
	}
}
