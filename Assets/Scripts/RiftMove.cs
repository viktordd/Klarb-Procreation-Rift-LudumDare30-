using UnityEngine;
using System.Collections;

public class RiftMove : MonoBehaviour
{

    public Camera camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    this.transform.position = new Vector3(0, camera.transform.position.y);
	}
}
