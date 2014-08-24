using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChunkManager
{

<<<<<<< HEAD
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// GetAllChunks, depending on the level will create a left and a right list of chunks.
    /// The earlier levels will be very similar while the later levels will have inverse and 
    /// jumps as well as non-matching chunks.
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public Level GetAllChunks(int level)
    {
        Level currentLevel = new Level();
        ////Figure out based off level what the leftside and rightside will be. 
        //Chunk chunk = new Chunk();
        //chunk.Name = "Chunk1-5";
        //chunk.Height = Convert.ToInt32(chunk.Name.Substring(chunk.Name.IndexOf("-") + 1));
        //currentLevel.LeftChunks.Add(chunk);
        //currentLevel.RightChunks.Add(chunk);
        return currentLevel;
    }
=======
	// Use this for initialization
	private void Start()
	{

	}

	// Update is called once per frame
	private void Update()
	{

	}

	/// <summary>
	/// GetAllChunks, depending on the level will create a left and a right list of chunks.
	/// The earlier levels will be very similar while the later levels will have inverse and 
	/// jumps as well as non-matching chunks.
	/// </summary>
	/// <param name="level"></param>
	/// <returns></returns>
	public Level GetAllChunks(int level)
	{
		Level currentLevel = new Level();
		//Figure out based off level what the leftside and rightside will be. 
		Chunk chunk = new Chunk();
		chunk.Name = "Chunk1-5";
		//chunk.Height = Convert.ToInt32(chunk.Name.Substring(chunk.Name.IndexOf("-") + 1));
		currentLevel.LeftChunks.Add(chunk);
		currentLevel.RightChunks.Add(chunk);
		return currentLevel;
	}
>>>>>>> origin/master
}

public class Chunk
{
    public List<ChunkRow> Rows { get; set; }
    public string Name { get; set; }
    public int Difficulty { get; set; }
    public Boolean StartFarLeft { get; set; }
    public Boolean StartMidLeft { get; set; }
    public Boolean StartMidRight { get; set; }
    public Boolean StartFarRight { get; set; }
    public Boolean EndFarLeft { get; set; }
    public Boolean EndMidLeft { get; set; }
    public Boolean EndMidRight { get; set; }
    public Boolean EndFarRight { get; set; }
    public Chunk()
    {
    }
}
public class Level
{
    public List<Chunk> LeftChunks { get; set; }
    public List<Chunk> RightChunks { get; set; }
    public Level()
    {
        LeftChunks = new List<Chunk>();
        RightChunks = new List<Chunk>();
    }
}
public class ChunkRow
{
    public Boolean FarLeft { get; set; }
    public Boolean MidLeft { get; set; }
    public Boolean MidRight { get; set; }
    public Boolean FarRight { get; set; }
    public ChunkRow()
    {

    }
}
