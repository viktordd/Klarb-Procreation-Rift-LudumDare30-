using UnityEngine;
using System.Collections;

public class TextureScript : MonoBehaviour {

	public Texture2D[] Textures;
    //public GUIText TextNote;
    private const float timeBetweenTransition = 3.0f;
    private const float fadeSpeed = 3.5f;
    private float counter = 0;
    private int currentSlide = 0;
    private float opacityValue = 0.5f;
    private bool fadingOut = false;
    private bool fadingIn = false;

	// Use this for initialization
	void Start () {
        loadSlide();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("EscapeKey") || Input.GetButton("JoyConfirmKey"))
        {
            goToGame();
        }

        counter += Time.deltaTime;
        if (!fadingOut && !fadingIn && counter >= timeBetweenTransition)
        {
            fadingOut = true;
        }

        if (fadingOut)
        {
            Color textureColor = GetComponent<GUITexture>().color;
            textureColor.a = opacityValue;
            this.GetComponent<GUITexture>().color = textureColor;
            opacityValue -= (Time.deltaTime / fadeSpeed);
            if (opacityValue <= 0.0f)
            {
                fadingOut = false;
                fadingIn = true;
                currentSlide++;
                loadSlide();
            }
        }
        if (fadingIn)
        {
            Color textureColor = GetComponent<GUITexture>().color;
            textureColor.a = opacityValue;
            this.GetComponent<GUITexture>().color = textureColor;
            opacityValue += (Time.deltaTime / fadeSpeed);
            if (opacityValue >= 0.5f)
            {
                fadingIn = false;
                counter = 0;
            }
        }
	}

    private void loadSlide()
    {
        if (currentSlide + 1 > Textures.Length)
        {
            goToGame();
        }
        else
        {
            this.GetComponent<GUITexture>().texture = Textures[currentSlide];
        }
        this.GetComponent<GUIText>().text = "(Press Esc to skip)";
        this.GetComponent<GUIText>().transform.Translate(0, 0, 9999);
    }

    private void goToGame()
    {
        Application.LoadLevel("main");
    }
}
