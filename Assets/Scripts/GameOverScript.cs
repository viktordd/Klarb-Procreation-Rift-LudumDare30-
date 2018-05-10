using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    public List<MyButton> ButtonList;
    private int currentIndex = 0;
    private bool m_isAxisInUseY = false;
    private bool isUpOrDownHeld = false;


    // Use this for initialization
    void Start()
	{        
        if (Input.GetAxisRaw("JoyVerticalLeft") != 0 || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
        {
            isUpOrDownHeld = true;
        }

		ButtonList[currentIndex].Select();
        ButtonList[0].ButtonFunction = () => { SceneManager.LoadScene("main"); };
        ButtonList[1].ButtonFunction = () => { SceneManager.LoadScene("TitleScreen"); };
    }

    // Update is called once per frame
    void Update()
    {       

        if (isUpOrDownHeld == true &&
            (Input.GetAxisRaw("JoyVerticalLeft") != 0 || Input.GetButtonDown("DownKey") || Input.GetButtonDown("UpKey")))
        {
            return;
        }

        if (Input.GetAxisRaw("JoyVerticalLeft") != 0 && m_isAxisInUseY == false && isUpOrDownHeld == false)
        {
            currentIndex = HelperClass.HandleMenuButtons(ButtonList, currentIndex);
            m_isAxisInUseY = true;
        }
        if (Input.GetAxisRaw("JoyVerticalLeft") == 0)
        {
            m_isAxisInUseY = false;
        }

        if (m_isAxisInUseY == false && isUpOrDownHeld == false)
            currentIndex = HelperClass.HandleMenuButtons(ButtonList, currentIndex);   
    }
}
