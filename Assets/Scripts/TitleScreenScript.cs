using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    public List<MyButton> ButtonList;
    private int currentIndex = 0;
    private bool m_isAxisInUseY = false;

    // Use this for initialization
    void Start()
    {
        ButtonList[currentIndex].Select();
        ButtonList[0].ButtonFunction = () =>
        {
            PlayerPrefs.SetInt("LevelNumber", LevelGenerator.MinLvl);
            PlayerPrefs.Save();
            SceneManager.LoadScene("SlideScene");
        };
        ButtonList[1].ButtonFunction = () => { SceneManager.LoadScene("ControlsScene"); };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("JoyVerticalLeft") != 0 && m_isAxisInUseY == false)
        {
            currentIndex = HelperClass.HandleMenuButtons(ButtonList, currentIndex);
            m_isAxisInUseY = true;
        }
        if (Input.GetAxisRaw("JoyVerticalLeft") == 0)
        {
            m_isAxisInUseY = false;
        }

        if (m_isAxisInUseY == false)
            currentIndex = HelperClass.HandleMenuButtons(ButtonList, currentIndex);
    }
}
