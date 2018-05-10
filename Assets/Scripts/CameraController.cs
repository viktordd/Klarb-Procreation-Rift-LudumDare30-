using System.Collections;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public Transform PlayerLeft;
    public Transform PlayerRight;
    public LevelNumber LevelNumber;

	// Use this for initialization
	void Start ()
	{	    
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerLeft == null || PlayerRight == null)
			return;
        if(PlayerLeft.position.y > PlayerRight.position.y)
            transform.position = new Vector3(0, ((PlayerLeft.position.y - PlayerRight.position.y) / 2) + PlayerRight.position.y, -10);
        if (PlayerRight.position.y > PlayerLeft.position.y)
            transform.position = new Vector3(0, ((PlayerRight.position.y - PlayerLeft.position.y) / 2) + PlayerLeft.position.y, -10);
	}

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 50), "Current Level: " + LevelNumber.LevelDiffNumber.ToString());
    }
}
