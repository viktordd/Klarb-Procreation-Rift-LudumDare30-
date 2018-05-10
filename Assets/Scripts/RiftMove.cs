using System.Collections;
using UnityEngine;

public class RiftMove : MonoBehaviour
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    this.transform.position = new Vector3(0, Camera.main.transform.position.y);
	}
}
