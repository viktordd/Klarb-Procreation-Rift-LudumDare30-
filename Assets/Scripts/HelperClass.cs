using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperClass {

    public static int HandleMenuButtons(List<MyButton> buttonList, int currentIndex)
    {
        
        if (Input.GetButtonDown("ConfirmKey") || Input.GetButtonDown("JoyConfirmKey"))
        {
            buttonList[currentIndex].Hit();
        }
        else if (Input.GetButtonDown("DownKey") || Input.GetAxisRaw("JoyVerticalLeft") == -1)
        {
            buttonList[currentIndex].Deselect();
            currentIndex++;
            if (currentIndex >= buttonList.Count)
            {
                currentIndex = 0;
            }
			buttonList[currentIndex].Select();
        }
        else if (Input.GetButtonDown("UpKey") || Input.GetAxisRaw("JoyVerticalLeft") == 1)
        {
            buttonList[currentIndex].Deselect();
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = (buttonList.Count - 1);
			}
			buttonList[currentIndex].Select();
        }
        return currentIndex;
    }
}
