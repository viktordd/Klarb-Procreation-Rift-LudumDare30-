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
    public GameObject[] chunkPrefabs; 

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
        var topOfChunk = 0;
        var botOfChunk = 0;
        var chunkLength = 0;
        Vector3 position = new Vector3();
        
        while (topOfChunk < SizeOfStage)
        {
            int randomNum = Random.Range(1, chunks.Count);
            var chunk = chunks[randomNum - 1];
            chunkLength = chunk.ChunkLength;
            position = new Vector3(-5.0f, topOfChunk);

            foreach (var chunkPrefab in chunkPrefabs )
            {
                if (chunkPrefab.name == chunk.ChunkName)
                {
                    Instantiate(chunkPrefab, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
            }

            
            topOfChunk += chunkLength;
        }
    }
}