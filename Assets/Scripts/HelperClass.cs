using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HelperClass {

    public static int HandleMenuButtons(List<MyButton> buttonList, int currentIndex)
    {
        buttonList[currentIndex].Select();

        if (Input.GetButtonDown("ConfirmKey"))
        {
            buttonList[currentIndex].Hit();
        }
        else if (Input.GetButtonDown("DownKey"))
        {
            buttonList[currentIndex].Deselect();
            currentIndex++;
            if (currentIndex >= buttonList.Count)
            {
                currentIndex = 0;
            }
        }
        else if (Input.GetButtonDown("UpKey"))
        {
            buttonList[currentIndex].Deselect();
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = (buttonList.Count - 1);
            }
        }
        return currentIndex;
    }
}
