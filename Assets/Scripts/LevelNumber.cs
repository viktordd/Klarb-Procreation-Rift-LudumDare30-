using UnityEngine;
using System.Collections;

public class LevelNumber : MonoBehaviour
{
	public const int MinLvl = 1;
	public int LevelDiffNumber { get; set; }

	// Use this for initialization
	void Awake()
	{
		int lvlNum = PlayerPrefs.GetInt("LevelNumber");

		if (lvlNum <= LevelGenerator.MinLvl)
		{
			PlayerPrefs.SetInt("LevelNumber", LevelGenerator.MinLvl);
			PlayerPrefs.Save();
			LevelDiffNumber = LevelGenerator.MinLvl;
		}
		else if (lvlNum > LevelGenerator.MinLvl)
			LevelDiffNumber = lvlNum;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
