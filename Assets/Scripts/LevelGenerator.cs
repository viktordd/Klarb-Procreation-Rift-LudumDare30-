using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	public const int MinLvl = 1;
    public LevelNumber LevelNumber;
    private int LevelOfStage;
    public int SizeOfStage;
    public ChunkManager ChunkManager;
    private Level level;
    public GameObject leftTile;
    public GameObject rightTile;
    public GameObject startTile;
    public GameObject endTile;
    public Chunk[] Chunks;
	// Use this for initialization
	void Start ()
	{
        LevelOfStage = LevelNumber.LevelDiffNumber;
		if (LevelOfStage < MinLvl)
			LevelOfStage = MinLvl;
        ChunkManager = new ChunkManager();
        level = ChunkManager.GetAllChunks(LevelOfStage);

	    GenerateLevel();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void GenerateLevel()
	{
		float crumbleSpeed = GetCrumbleSpeed();
        int heighestLeftChunk = 0;
        int heighestRightChunk = 0;
        Vector3 position = new Vector3();
        position = new Vector3(-5.0f, heighestLeftChunk - 2);
        Instantiate(startTile, position, Quaternion.AngleAxis(0, Vector3.forward));
        position = new Vector3(-5.0f, heighestLeftChunk - 1);
        Instantiate(startTile, position, Quaternion.AngleAxis(0, Vector3.forward));
        position = new Vector3(5.0f, heighestLeftChunk - 2);
        Instantiate(startTile, position, Quaternion.AngleAxis(0, Vector3.forward));
        position = new Vector3(5.0f, heighestLeftChunk - 1);
        Instantiate(startTile, position, Quaternion.AngleAxis(0, Vector3.forward));
        foreach (Chunk chunk in level.LeftChunks)
        {
            foreach (Row row in chunk.Rows)
            {
                if (row.FarLeft)
                {
					position = new Vector3(-5.0f, heighestLeftChunk);
					InstantiateTile(leftTile, position, crumbleSpeed);
                }
	            if (row.MidLeft)
                {
					position = new Vector3(-4.0f, heighestLeftChunk);
					InstantiateTile(leftTile, position, crumbleSpeed);
                }
                if (row.MidRight)
                {
					position = new Vector3(-3.0f, heighestLeftChunk);
					InstantiateTile(leftTile, position, crumbleSpeed);
                }
                if (row.FarRight)
                {
					position = new Vector3(-2.0f, heighestLeftChunk);
					InstantiateTile(leftTile, position, crumbleSpeed);
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
					InstantiateTile(rightTile, position, crumbleSpeed);
                }
                if (row.MidLeft)
                {
					position = new Vector3(3.0f, heighestRightChunk);
					InstantiateTile(rightTile, position, crumbleSpeed);
                }
                if (row.MidRight)
                {
					position = new Vector3(4.0f, heighestRightChunk);
					InstantiateTile(rightTile, position, crumbleSpeed);
                }
                if (row.FarRight)
                {
					position = new Vector3(5.0f, heighestRightChunk);
					InstantiateTile(rightTile, position, crumbleSpeed);
                }
                heighestRightChunk++;
            }
        }

        position = new Vector3(-5.0f, heighestLeftChunk);
        Instantiate(endTile, position, Quaternion.AngleAxis(0, Vector3.forward));
        position = new Vector3(-4.0f, heighestLeftChunk);
        Instantiate(endTile, position, Quaternion.AngleAxis(0, Vector3.forward));
        position = new Vector3(-3.0f, heighestLeftChunk);
        Instantiate(endTile, position, Quaternion.AngleAxis(0, Vector3.forward));
        position = new Vector3(-2.0f, heighestLeftChunk);
        Instantiate(endTile, position, Quaternion.AngleAxis(0, Vector3.forward));
        position = new Vector3(-1.0f, heighestLeftChunk);
        Instantiate(endTile, position, Quaternion.AngleAxis(0, Vector3.forward));
        position = new Vector3(0.0f, heighestLeftChunk);
        Instantiate(endTile, position, Quaternion.AngleAxis(0, Vector3.forward));
        position = new Vector3(1.0f, heighestLeftChunk);
        Instantiate(endTile, position, Quaternion.AngleAxis(0, Vector3.forward));
        position = new Vector3(2.0f, heighestLeftChunk);
        Instantiate(endTile, position, Quaternion.AngleAxis(0, Vector3.forward));
        position = new Vector3(3.0f, heighestLeftChunk);
        Instantiate(endTile, position, Quaternion.AngleAxis(0, Vector3.forward));
        position = new Vector3(4.0f, heighestLeftChunk);
        Instantiate(endTile, position, Quaternion.AngleAxis(0, Vector3.forward));
        position = new Vector3(5.0f, heighestLeftChunk);
        Instantiate(endTile, position, Quaternion.AngleAxis(0, Vector3.forward));
    }

	private float GetCrumbleSpeed()
	{
		switch (LevelOfStage)
		{
			case 1:
			case 2:
				return 0f;
			case 3:
			case 4:
				return 1f;
			case 5:
			case 6:
				return 2f;
			case 7:
			case 8:
				return 3f;
			case 9:
			case 10:
				return 4f;
			default:
				return 5f;
		}
	}

	private void InstantiateTile(GameObject tile, Vector3 position, float crumbleSpeed)
	{
		var obj = Instantiate(tile, position, Quaternion.AngleAxis(0, Vector3.forward)) as GameObject;
		var controller = obj.GetComponent<TileController>();
		controller.crumbleSpeed = crumbleSpeed;
	}
}