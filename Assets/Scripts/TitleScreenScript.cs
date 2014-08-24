using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TitleScreenScript : MonoBehaviour
{
    public List<MyButton> ButtonList;
    private int currentIndex = 0;

    // Use this for initialization
    void Start()
    {
        ButtonList[0].ButtonFunction = () => { Application.LoadLevel("SlideScene"); };
        ButtonList[0].ButtonFunction = () => { Application.LoadLevel("SlideScene"); };
    }

    // Update is called once per frame
    void Update()
    {
        ButtonList[currentIndex].Select();

        if (Input.GetButtonDown("ConfirmKey"))
        {
            ButtonList[currentIndex].Hit();
        }
        else if (Input.GetButtonDown("DownKey"))
        {
            ButtonList[currentIndex].Deselect();
            currentIndex++;
            if (currentIndex >= ButtonList.Count)
            {
                currentIndex = 0;
            }
        }
        else if (Input.GetButtonDown("UpKey"))
        {
            ButtonList[currentIndex].Deselect();
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = (ButtonList.Count - 1);
            }
        }
    }
}
