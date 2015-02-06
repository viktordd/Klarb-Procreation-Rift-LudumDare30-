using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private const int jumpSFXindx = 0;
	private const int fallSFXindx = 1;
	private const float moveSpeed = 3f;


    public string player;
    private string horizontal = string.Empty;
    private string vertical = string.Empty;
    private string joyHorizontal = string.Empty;
    private string joyVertical = string.Empty;
	private string jump = string.Empty;
    private string joyJump = string.Empty;
	
	public bool Jumping { get { return jumping; } }
	private bool hasGroundBelow = true;
	private bool isAtEnd = false;
	private bool jumping = false;
	private bool endJump = false;
	private bool dead = false;

    public ResetLevel levelReset;    

    public Transform groundCheck;
	private float groundRadius = 0.15f;
	public LayerMask whatIsGround;
	public LayerMask whatIsEnd;

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
	    joyHorizontal = "JoyHorizontal" + player;
        joyVertical = "JoyVertical" + player;
		jump = "Jump" + player;
	    joyJump = "JoyJump" + player;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (dead)
			SetPlayerAsDead();
		else
			PlayerInput();
	}

	void PlayerInput()
	{
		hasGroundBelow = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		float hAxis = Input.GetAxis(horizontal);
		float vAxis = Input.GetAxis(vertical);
	    float joyhAxis = Input.GetAxisRaw(joyHorizontal);
        float joyvAxis = Input.GetAxisRaw(joyVertical);
		bool jumpTrig = (Input.GetButton(jump) || Input.GetButton(joyJump)) && !endJump;
		if (endJump) endJump = false;

        Vector2 move = new Vector2(hAxis * moveSpeed, vAxis * moveSpeed);

        if (Input.GetAxisRaw(joyHorizontal) != 0 || Input.GetAxisRaw(joyVertical) != 0)
            move = new Vector2(joyhAxis * moveSpeed, joyvAxis * moveSpeed);
        // joyhAxis *
        //joyvAxis* 
		move = Vector2.ClampMagnitude(move, moveSpeed);
		anim.SetFloat("Speed", move.magnitude);

		if (Input.GetButton(horizontal) || Input.GetButton(vertical) || Input.GetAxisRaw(joyHorizontal) != 0 || Input.GetAxisRaw(joyVertical) != 0)
		{
			var angle = Mathf.Atan2(move.y, move.x)*Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
		}

		if (jumpTrig && !jumping && hasGroundBelow)
		{
			jumping = true;
			anim.SetBool("Jump", true);
			audio[jumpSFXindx].Play();
		}

		if (!jumping && !hasGroundBelow)
		{
			StartFallSequence(move);
			return;
		}
		isAtEnd = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsEnd);
		if (isAtEnd)
			SetPlayerAtEnd();

		rigidbody2D.velocity = move;
	}

	// Called from at the end of Jump of animation.
	public void EndJump()
	{
		endJump = true;
		jumping = false;
		anim.SetBool("Jump", false);
		if (!hasGroundBelow)
		{
			StartFallSequence(rigidbody2D.velocity);
		}
	}

	private void StartFallSequence(Vector2 move)
	{
		dead = true;
		anim.SetBool("Fall", true);
		audio[fallSFXindx].Play();
		Destroy(collider2D);
		spriteRenderer.sortingLayerName = "Falling Player";
		rigidbody2D.velocity = Vector2.ClampMagnitude(move, moveSpeed/3f);
	}

	// Called from at the end of Jump of animation.
	public void EndFall()
	{
		Destroy(spriteRenderer);
	}

	public void SetPlayerAsDead()
	{
		if (audio[fallSFXindx].isPlaying)
			return;
		if (player == "Left")
	    {
	        levelReset.PlayerLeftDead = true;
	    }
		else if (player == "Right")
	    {
	        levelReset.PlayerRightDead = true;
	    }
	}

	public void SetPlayerAtEnd()
	{
		if (player == "Left")
		{
			levelReset.PlayerLeftAtEnd = true;
		}
		else if (player == "Right")
		{
			levelReset.PlayerRightAtEnd = true;
		}
	}
}
