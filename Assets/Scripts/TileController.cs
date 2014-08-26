using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileController : MonoBehaviour
{
	public string Tile;
	public float crumbleSpeed = 0f;

	private Animator anim;
	private SpriteRenderer spriteRenderer;
	private bool crumbling = false;
	private PlayerController player;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		SwitchHelper.Switch(anim, Tile);
	}

	// Update is called once per frame
	void Update()
	{
		anim.SetFloat("CrumbleSpeed", crumbleSpeed);
		if (!crumbling && player != null && !player.Jumping)
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
		if (!crumbling && otherObject.CompareTag("Player"))
		{
			player = null;
		}
	}

	private void StartCrumbling()
	{
		crumbling = true;
		anim.SetBool("Crumbling", true);
	}

	public void StartFalling()
	{
		spriteRenderer.sortingLayerName = "Falling Tile";
		Destroy(collider2D);
	}

	public void EndFalling()
	{
		Destroy(gameObject);
	}
}