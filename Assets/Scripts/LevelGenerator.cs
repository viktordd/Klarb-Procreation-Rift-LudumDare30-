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
    public GameObject leftTile;
    public GameObject rightTile;
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

        foreach (Chunk chunk in level.LeftChunks)
        {
            foreach (Row row in chunk.Rows)
            {
                if (row.FarLeft)
                {
                    position = new Vector3(-5.0f, heighestChunk);
                    Instantiate(leftTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
                if (row.MidLeft)
                {
                    position = new Vector3(-4.0f, heighestChunk);
                    Instantiate(leftTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
                if (row.MidRight)
                {
                    position = new Vector3(-3.0f, heighestChunk);
                    Instantiate(leftTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
                if (row.FarRight)
                {
                    position = new Vector3(-2.0f, heighestChunk);
                    Instantiate(leftTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
            }
            heighestChunk++;
        }
        heighestChunk = 0;
        foreach (Chunk chunk in level.RightChunks)
        {
            foreach (Row row in chunk.Rows)
            {
                if (row.FarLeft)
                {
                    position = new Vector3(2.0f, heighestChunk);
                    Instantiate(rightTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
                if (row.MidLeft)
                {
                    position = new Vector3(3.0f, heighestChunk);
                    Instantiate(rightTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
                if (row.MidRight)
                {
                    position = new Vector3(4.0f, heighestChunk);
                    Instantiate(rightTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
                if (row.FarRight)
                {
                    position = new Vector3(5.0f, heighestChunk);
                    Instantiate(rightTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
            }
            heighestChunk++;
        }
    }
}