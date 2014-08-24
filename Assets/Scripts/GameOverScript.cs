using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOverScript : MonoBehaviour {

    public List<MyButton> ButtonList;
    private int currentIndex = 0;

    // Use this for initialization
    void Start()
    {
        ButtonList[0].ButtonFunction = () => { Application.LoadLevel("main"); };
        ButtonList[1].ButtonFunction = () => { Application.LoadLevel("TitleScreen"); };
    }

    // Update is called once per frame
    void Update()
    {
        currentIndex = HelperClass.HandleMenuButtons(ButtonList, currentIndex);
    }
}
