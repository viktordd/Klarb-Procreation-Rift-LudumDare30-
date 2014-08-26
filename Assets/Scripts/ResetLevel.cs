using UnityEngine;
using System.Collections;

public class ResetLevel : MonoBehaviour
{

    public LevelNumber levelNumber;

	private bool bothPlayersAtEnd = false;

	public bool PlayerLeftAtEnd { get; set; }
	public bool PlayerRightAtEnd { get; set; }

	public bool PlayerLeftDead { get; set; }
    public bool PlayerRightDead { get; set; }


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

            PlayerPrefs.SetInt("LevelNumber", levelNumber.LevelDiffNumber);
			Application.LoadLevel("ProcreationScene");

			if (!bothPlayersAtEnd)
			{
				bothPlayersAtEnd = true;
				Invoke("GoToProcreationScene", 1f);
			}
		}
		else
		{
			bothPlayersAtEnd = false;
			CancelInvoke("GoToProcreationScene");

		}
	}

	void GoToProcreationScene()
	{
		Application.LoadLevel("ProcreationScene");
	}
}
