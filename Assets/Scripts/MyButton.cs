using System;
using System.Collections;
using UnityEngine;

public class MyButton : MonoBehaviour
{

    public Sprite[] SpriteCollection;
    public Action ButtonFunction;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        ButtonFunction();
    }
}
