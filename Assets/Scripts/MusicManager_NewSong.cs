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

		var audio = GetComponent<AudioSource>();

	    if (audio.clip != null && audio.clip.name == "menu" && NewMusic.name == "menu")
	    {
	        return;
	    }

	    audio.clip = NewMusic;
	    audio.Play();
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
