using UnityEngine;
using System.Collections;

public class ControlsScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("ConfirmKey") || Input.GetButtonDown("JoyConfirmKey"))
        {
            Application.LoadLevel("TitleScreen");
        }
	}
}
