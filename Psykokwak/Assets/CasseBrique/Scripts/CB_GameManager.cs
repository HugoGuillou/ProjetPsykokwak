using UnityEngine;
using System.Collections;

public class CB_GameManager : MonoBehaviour {

	public int brickRows = 6;
	public int brickCols = 6;

	private CB_Brick[][] bricks;

	private float BrickAppearTimer = 10;

	public int brickSpanTime = 10;
	private float brickSpanTimeLeft;

	public CB_Brick brickPrefab;

	// Use this for initialization
	void Start () {
	
		bricks = new CB_Brick[brickRows][];
		for(int i=0; i<brickRows; ++i) 
		{
			bricks[i] = new CB_Brick[brickCols];
			for(int j=0; j<brickCols; ++j)
			{
				bricks[i][j] = null;
			}
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

		for(int j=0; j < brickCols; ++j)
		{
			if(bricks[brickCols-1][j] != null)
				destroyBrick(bricks[brickCols-1][j]);
		}

	

		Debug.Log("Append");

		for (int i=brickRows-1; i>0; --i) 
		{

			for(int j=0; j < brickCols; ++j)
			{
				if(bricks[i-1][j] != null)
				{
					Vector3 pos = bricks[i-1][j].transform.position;
					pos.y -= 1.5f;

					bricks[i-1][j].transform.position = pos;

				}
				
				bricks[i][j] = bricks[i-1][j];
			}
		}


		for(int j=0; j < brickCols; ++j)
		{
			Vector3 brickPos = transform.position;
			brickPos.x += (j * 3.2f) + 0.18f;

			CB_Brick b = Instantiate(brickPrefab, brickPos, transform.rotation) as CB_Brick; 
			bricks[0][j] = b;
		}


	}

	public void destroyBrick(CB_Brick brick)
	{
		for (int i=0; i< brickRows-1; ++i) 
		{
			for(int j=0; j < brickCols; ++j)
			{
				if(bricks[i][j] == brick)
				{
					Destroy (brick.gameObject);
					bricks[i][j] = null;
					return;
				}
			}
		}
	}
}
