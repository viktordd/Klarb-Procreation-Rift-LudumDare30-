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

        if (PlayerLeftDead || PlayerRightDead)
        {
            Application.LoadLevel("GameOverScene");
		}

		if (PlayerLeftAtEnd && PlayerRightAtEnd)
		{
			Application.LoadLevel("ProcreationScene");
		}
	}

	public bool PlayerLeftAtEnd { get; set; }
	public bool PlayerRightAtEnd { get; set; }


	public bool PlayerLeftDead { get; set; }
    public bool PlayerRightDead { get; set; }

}
