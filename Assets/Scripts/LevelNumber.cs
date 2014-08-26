using UnityEngine;
using System.Collections;

public class LevelNumber : MonoBehaviour
{

    
    public int LevelDiffNumber { get; set; }
    private bool firstLoad = true;

	// Use this for initialization
	void Awake ()
	{
	    if (PlayerPrefs.GetInt("FirstLoad", 1) == 0)
	    {
	        firstLoad = false;
	    }

	    if (PlayerPrefs.GetInt("LevelNumber") > 1 && firstLoad == false)
	        LevelDiffNumber = PlayerPrefs.GetInt("LevelNumber");
        else if (PlayerPrefs.GetInt("LevelNumber") > 1 && firstLoad == true)
        {
            PlayerPrefs.SetInt("FirstLoad", 0);
            PlayerPrefs.SetInt("LevelNumber", 1);
            LevelDiffNumber = 1;
        }
        else
        {
            LevelDiffNumber = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
