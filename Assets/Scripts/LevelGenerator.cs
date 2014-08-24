using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    public int LevelOfStage;
    public int SizeOfStage;
    public ChunkManager ChunkManager;
    private Level level;
    public GameObject[] chunkPrefabs;
    public Chunk[] Chunks;
	// Use this for initialization
	void Start ()
	{
        ChunkManager = new ChunkManager();
        level = ChunkManager.GetAllChunks(LevelOfStage);

	    GenerateLevel();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void GenerateLevel()
    {
        int heighestChunk = 0;
        Vector3 position = new Vector3();

        while (heighestChunk < SizeOfStage)
        {
            int randomNum = Random.Range(1, level.LeftChunks.Count);
            Chunk chunk = level.LeftChunks[randomNum - 1];
            position = new Vector3(-5.0f, heighestChunk);

            foreach (GameObject chunkPrefab in chunkPrefabs)
            {
                if (chunkPrefab.name == chunk.Name)
                {
                    Instantiate(chunkPrefab, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
            }
            //heighestChunk += chunk.Height;
        }
        heighestChunk = 0;
        while (heighestChunk < SizeOfStage)
        {
            int randomNum = Random.Range(1, level.RightChunks.Count);
            Chunk chunk = level.RightChunks[randomNum - 1];
            position = new Vector3(5.0f, heighestChunk);

            foreach (GameObject chunkPrefab in chunkPrefabs)
            {
                if (chunkPrefab.name == chunk.Name)
                {
                    Instantiate(chunkPrefab, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
            }
            //heighestChunk += chunk.Height;
        }
    }
}