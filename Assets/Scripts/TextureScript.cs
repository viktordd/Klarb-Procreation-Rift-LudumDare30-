using UnityEngine;
using System.Collections;

public class TextureScript : MonoBehaviour {

	public Texture2D[] Textures;
	// Use this for initialization
	void Start () {
        this.guiTexture.texture = Textures[0];
	}
	
	// Update is called once per frame
	void Update () {

	}
}
