using UnityEngine;
using System.Collections;

public class CB_GameManager : MonoBehaviour {

	public int brickRows = 6;
	public int brickCols = 6;

	private Brick[][] bricks;

	private float BrickAppearTimer = 10;

	public int brickSpanTime = 10;
	private float brickSpanTimeLeft;

	public Brick brickPrefab;

	// Use this for initialization
	void Start () {
	
		bricks = new Brick[brickRows][];
		for(int i=0; i<brickRows; ++i) 
		{
			bricks[i] = new Brick[brickCols];
		}

		brickSpanTimeLeft = brickSpanTime;

	}
	
	// Update is called once per frame
	void Update () {

		brickSpanTimeLeft -= Time.deltaTime;
		if (brickSpanTimeLeft < 0) 
		{
			brickSpanTimeLeft = brickSpanTime;
			AppendLine ();
		}
	
	}

	void AppendLine()
	{
		for (int i=1; i< brickRows-1; ++i) 
		{
			for(int j=0; j < brickCols; ++j)
			{
				Transform currentBrick = bricks[i][j].transform;

				Vector3 pos = currentBrick.position;
				pos.y += brickPrefab.height;
				currentBrick.position = pos;

				bricks[i+1][j] = bricks[i][j];
			}
		}

		for(int j=0; j < brickCols; ++j)
		{
			Brick b = Instantiate(brickPrefab, transform.position, transform.rotation) as Brick; 
			bricks[0][j] = b;
		}
	}
}
