using System.Collections;
using UnityEngine;

public class RiftMove : MonoBehaviour
{

    public Camera mainCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    this.transform.position = new Vector3(0, mainCamera.transform.position.y);
	}
}
