using UnityEngine;
using System.Collections;

public class MusicManager_NewSong : MonoBehaviour
{

    public AudioClip NewMusic;
    public AudioClip RandomBonusMusic;

	// Use this for initialization
	void Awake ()
	{
	    if (RandomBonusMusic)
	    {
	        var rand = Random.Range(0, 2);
	        if (rand == 1)
	            NewMusic = RandomBonusMusic;
	    }


	    var gameMusic = GameObject.Find("GameMusic");
	    gameMusic.audio.clip = NewMusic;
        gameMusic.audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
