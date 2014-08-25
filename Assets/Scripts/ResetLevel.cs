using UnityEngine;
using System.Collections;

public class ResetLevel : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Reset"))
		{
			Application.LoadLevel(Application.loadedLevelName);
		}

        if (PlayerLeftDead && PlayerRightDead)
        {
            Application.LoadLevel("GameOverScene");
        }
	}

    public bool PlayerRightDead { get; set; }

    public bool PlayerLeftDead { get; set; }
}
