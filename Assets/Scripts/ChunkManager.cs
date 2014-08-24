using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChunkManager
{

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

        //Figure out based off level what the leftside and rightside will be. 
        Chunk chunkl1 = new Chunk(1, false, false);
        Chunk chunkr1 = new Chunk(1, false, false);
        Chunk chunkl2 = new Chunk(2, false, false);
        Chunk chunkr2 = new Chunk(2, false, false);
        Chunk chunkl3 = new Chunk(3, false, false);
        Chunk chunkr3 = new Chunk(3, true, false);
        //chunk.Rows.Count = Convert.ToInt32(chunk.Name.Substring(chunk.Name.IndexOf("-") + 1));
        currentLevel.LeftChunks.Add(chunkl1); 
        currentLevel.LeftChunks.Add(chunkl2); 
        currentLevel.LeftChunks.Add(chunkl3);
        currentLevel.RightChunks.Add(chunkr1); 
        currentLevel.RightChunks.Add(chunkr2); 
        currentLevel.RightChunks.Add(chunkr3);
        return currentLevel;
    }
}
public class Chunk
{
    public List<Row> Rows { get; set; }
    public int Difficulty { get; set; }
    public Chunk(int diff, bool inverse, bool jump)
    {
        Rows = new List<Row>();
        switch (diff)
        {
            case 1:
                Row.AddRow(false, true, true, false, inverse, jump, Rows);
                Row.AddRow(false, true, true, false, inverse, jump, Rows);
                Row.AddRow(false, null, true, false, inverse, jump, Rows);
                Row.AddRow(false, true, null, false, inverse, jump, Rows);
                Row.AddRow(false, true, true, false, inverse, jump, Rows);
                break;
            case 2:
                Row.AddRow(false, true, true, false, inverse, jump, Rows);
                Row.AddRow(true, true, true, true, inverse, jump, Rows);
                Row.AddRow(true, false, false, true, inverse, jump, Rows);
                Row.AddRow(true, true, true, true, inverse, jump, Rows);
                Row.AddRow(true, true, true, true, inverse, jump, Rows);
                break;
            case 3:
                Row.AddRow(false, true, true, false, inverse, jump, Rows);
                Row.AddRow(false, false, true, false, inverse, jump, Rows);
                Row.AddRow(false, false, true, false, inverse, jump, Rows);
                Row.AddRow(false, false, true, false, inverse, jump, Rows);
                Row.AddRow(false, true, true, false, inverse, jump, Rows);
                break;
            case 4:
                Row.AddRow(true, true, true, true, inverse, jump, Rows);
                Row.AddRow(true, false, false, false, inverse, jump, Rows);
                Row.AddRow(true, true, true, true, inverse, jump, Rows);
                Row.AddRow(false, false, false, true, inverse, jump, Rows);
                Row.AddRow(true, true, true, true, inverse, jump, Rows);
                break;
            default:
                break;
        }
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
public class Row
{
    public Boolean FarLeft { get; set; }
    public Boolean MidLeft { get; set; }
    public Boolean MidRight { get; set; }
    public Boolean FarRight { get; set; }
    public Row(bool fl, bool ml, bool mr, bool fr)
    {
        FarLeft = fl;
        MidLeft = ml;
        MidRight = mr;
        FarRight = fr;
    }
    public static void AddRow(bool? fl, bool? ml, bool? mr, bool? fr, bool inverse, bool jump, List<Row> rows)
    {
        if (inverse)
            if (jump)
                rows.Add(new Row(fr == null ? false : (bool)fr, mr == null ? false : (bool)mr, ml == null ? false : (bool)ml, fl == null ? false : (bool)fl));//inverse + jump
            else
                rows.Add(new Row(fr == null ? true : (bool)fr, mr == null ? true : (bool)mr, ml == null ? true : (bool)ml, fl == null ? true : (bool)fl));//inverse
        else
            if (jump)
                rows.Add(new Row(fl == null ? false : (bool)fl, ml == null ? false : (bool)ml, mr == null ? false : (bool)mr, fr == null ? false : (bool)fr));//jump
            else
                rows.Add(new Row(fl == null ? true : (bool)fl, ml == null ? true : (bool)ml, mr == null ? true : (bool)mr, fr == null ? true : (bool)fr));//normal
    }
}