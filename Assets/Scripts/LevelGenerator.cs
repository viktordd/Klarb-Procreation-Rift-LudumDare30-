using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int LevelOfStage = 1;
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
		float crumbleSpeed = GetCrumbleSpeed();
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
    }

	private float GetCrumbleSpeed()
	{
		switch (LevelOfStage)
		{
			case 1:
			case 2:
				return 0f;
				break;
			case 3:
			case 4:
				return 1f;
				break;
			case 5:
			case 6:
				return 2f;
				break;
			case 7:
			case 8:
				return 3f;
				break;
			case 9:
			case 10:
				return 4f;
				break;
			default:
				return 5f;
				break;
		}
	}

	private void InstantiateTile(GameObject tile, Vector3 position, float crumbleSpeed)
	{
		var obj = Instantiate(tile, position, Quaternion.AngleAxis(0, Vector3.forward)) as GameObject;
		var controller = obj.GetComponent<TileController>();
		controller.crumbleSpeed = crumbleSpeed;
	}
}