using UnityEngine;
using System.Collections;

public class MyButton : MonoBehaviour {

    public Sprite[] SpriteCollection;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnMouseEnter()
    {
        Select();
    }
    void OnMouseExit()
    {
        Deselect();
    }
    void OnMouseDown()
    {
        Hit();
    }

    public void Select()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteCollection[1];
    }
    public void Deselect()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteCollection[0];
    }
    public void Hit()
    {
        Application.LoadLevel("SlideScene");
    }
}
