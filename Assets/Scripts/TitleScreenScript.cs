﻿using UnityEngine;
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
        ButtonList[1].ButtonFunction = () => { Application.LoadLevel("ControlsScene"); };
    }

    // Update is called once per frame
    void Update()
    {
        currentIndex = HelperClass.HandleMenuButtons(ButtonList, currentIndex);
    }
}