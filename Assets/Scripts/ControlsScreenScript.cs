using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("ConfirmKey") || Input.GetButtonDown("JoyConfirmKey"))
        {
            SceneManager.LoadScene("TitleScreen");
        }
	}
}
