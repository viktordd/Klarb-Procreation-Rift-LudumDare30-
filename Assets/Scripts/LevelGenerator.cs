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
        int heighestLeftChunk = 0;
        int heighestRightChunk = 0;
        Vector3 position = new Vector3();

        foreach (Chunk chunk in level.LeftChunks)
        {
            foreach (Row row in chunk.Rows)
            {
                if (row.FarLeft)
                {
                    position = new Vector3(-5.0f, heighestLeftChunk);
                    Instantiate(leftTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
                if (row.MidLeft)
                {
                    position = new Vector3(-4.0f, heighestLeftChunk);
                    Instantiate(leftTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
                if (row.MidRight)
                {
                    position = new Vector3(-3.0f, heighestLeftChunk);
                    Instantiate(leftTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
                if (row.FarRight)
                {
                    position = new Vector3(-2.0f, heighestLeftChunk);
                    Instantiate(leftTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
                heighestLeftChunk++;
            }
        }
        foreach (Chunk chunk in level.RightChunks)
        {
            foreach (Row row in chunk.Rows)
            {
                if (row.FarLeft)
                {
                    position = new Vector3(2.0f, heighestRightChunk);
                    Instantiate(rightTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
                if (row.MidLeft)
                {
                    position = new Vector3(3.0f, heighestRightChunk);
                    Instantiate(rightTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
                if (row.MidRight)
                {
                    position = new Vector3(4.0f, heighestRightChunk);
                    Instantiate(rightTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
                if (row.FarRight)
                {
                    position = new Vector3(5.0f, heighestRightChunk);
                    Instantiate(rightTile, position, Quaternion.AngleAxis(0, Vector3.forward));
                }
                heighestRightChunk++;
            }
        }
    }
}