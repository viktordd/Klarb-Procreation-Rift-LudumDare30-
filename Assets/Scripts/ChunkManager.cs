using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChunkManager
{

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public List<Chunk> GetAllChunks()
    {
        var list = new List<Chunk>();
        Chunk chunk = new Chunk();
        chunk.ChunkName = "Chunk1-5";
        chunk.ChunkLength = Convert.ToInt32(chunk.ChunkName.Substring(chunk.ChunkName.IndexOf("-") + 1));
        list.Add(chunk);
        return list;
    }
}

public class Chunk
{
    public int ChunkLength { get; set; }
    public string ChunkName { get; set; }
    public Chunk()
    {        
    }
}
