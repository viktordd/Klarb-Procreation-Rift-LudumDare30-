using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

        if (PlayerLeftDead || PlayerRightDead)
        {
            SceneManager.LoadScene("GameOverScene");
		}

		if (PlayerLeftAtEnd && PlayerRightAtEnd)
		{
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
		SceneManager.LoadScene("ProcreationScene");
	}
}
