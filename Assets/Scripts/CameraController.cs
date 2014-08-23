using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Transform PlayerLeft;
    public Transform PlayerRight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(0, (PlayerLeft.position.y - PlayerRight.position.y) / 2, -10);
	}
}
