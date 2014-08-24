using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour
{
	private Animator anim;
	private bool falling = false;
	private PlayerController player;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if (!falling && player != null && !player.Jumping)
		{
			StartFalling();
		}
	}

	void OnTriggerEnter2D(Collider2D otherObject)
	{
		if (otherObject.CompareTag("Player"))
		{
			PlayerController pl = otherObject.GetComponent<PlayerController>();
			if (pl.Jumping)
			{
				player = pl;
			}
			else
				StartFalling();
		}
	}

	void OnTriggerExit2D(Collider2D otherObject)
	{
		if (!falling && otherObject.CompareTag("Player"))
		{
			player = null;
		}
	}

	private void StartFalling()
	{
		falling = true;
		anim.SetBool("Falling", true);
	}

	public void EndFalling()
	{
		Destroy(gameObject);
	}
}
