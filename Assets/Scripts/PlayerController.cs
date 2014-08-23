using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float moveSpeed = 10f;

    public string player;
    private string horizontal = string.Empty;
    private string vertical = string.Empty;

	private bool grounded = false;
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
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		Debug.Log(grounded ? "Enter" : "Falling");
	    PlayerInput();          
	}

	void PlayerInput()
	{
		float haxis = Input.GetAxis(horizontal);
		float vaxis = Input.GetAxis(vertical);

		Vector2 move = new Vector2(haxis*moveSpeed, vaxis*moveSpeed);

		if (move.magnitude > 0.5)
		{
			var angle = Mathf.Atan2(move.y, move.x)*Mathf.Rad2Deg;

			transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
		}
		anim.SetFloat("Speed", move.magnitude);

		rigidbody2D.velocity = move;

		


		//if (Input.GetButton("LeftLeft"))
		//{         
		//    transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
		//}
		//if (Input.GetButton("LeftUp"))
		//{         
		//    transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
		//}
		//if (Input.GetButton("LeftDown"))
		//{         
		//    transform.Translate(-Vector2.up * moveSpeed * Time.deltaTime);
		//}
	}
}
