using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;

public class TileController : MonoBehaviour
{
	public string Tile;
	private Animator anim;
	private bool falling = false;
	private PlayerController player;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		AnimationSwitcher.Switch(anim, Tile);

	}
	
	// Update is called once per frame
	void Update () {
		if (!falling && player != null && !player.Jumping)
		{
			StartCrumbling();
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
				StartCrumbling();
		}
	}

	void OnTriggerExit2D(Collider2D otherObject)
	{
		if (!falling && otherObject.CompareTag("Player"))
		{
			player = null;
		}
	}

	private void StartCrumbling()
	{
		falling = true;
		anim.SetBool("Crumbling", true);
	}

	public void StartFalling()
	{
		Destroy(collider2D);
	}

	public void EndFalling()
	{
		Destroy(gameObject);
	}
}