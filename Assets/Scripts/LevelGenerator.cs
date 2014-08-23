using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    public int SizeOfStage;
    public ChunkManager ChunkManager;
    private List<Chunk> chunks;

	// Use this for initialization
	void Start ()
	{
        ChunkManager = new ChunkManager();
        chunks = ChunkManager.GetAllChunks();

	    GenerateLevel();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void GenerateLevel()
    {
        var currentStageLength = 0;
        var chunkLength = 0;
        int position, startPosition;

        startPosition = Random.Range(1, 6);

        while (currentStageLength < SizeOfStage)
        {
            int randomNum = Random.Range(1, chunks.Count);
            var chunk = chunks[randomNum - 1];
            chunkLength = chunk.ChunkLength;



            currentStageLength += chunkLength;
        }
    }
}