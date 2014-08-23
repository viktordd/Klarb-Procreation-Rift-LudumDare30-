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

    }

    // Update is called once per frame
    void Update()
    {
        ButtonList[currentIndex].Select();
        if (Input.GetButtonDown("DownKey"))
        {
            currentIndex++;
        }
        if (currentIndex >= ButtonList.Count)
        {
            currentIndex = 0;
        }
    }
}
