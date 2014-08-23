using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{

    private float moveSpeed = 8.0f;

    public string player;
    private string horizontal = string.Empty;
    private string vertical = string.Empty;

	private bool grounded = false;
	public Transform groundCheck;
	private float groundRadius = 0.02f;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start ()
	{
	    horizontal = "Horizontal" + player;
	    vertical = "Vertical" + player;
	}
	
	// Update is called once per frame
	void Update ()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		Debug.Log(grounded ? "Enter" : "Falling");
	    PlayerInput();          
	}

	private void PlayerInput()
	{
		float haxis = Input.GetAxis(horizontal);
		float vaxis = Input.GetAxis(vertical);
		transform.Translate(new Vector3(haxis, vaxis) * moveSpeed * Time.deltaTime);

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
