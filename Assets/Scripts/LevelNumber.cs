using UnityEngine;
using System.Collections;

public class LevelNumber : MonoBehaviour
{

    private static LevelNumber instance = null;
    public static LevelNumber Instance { get { return instance; } }
    public int LevelDiffNumber { get; set; }

	// Use this for initialization
	void Awake () {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
