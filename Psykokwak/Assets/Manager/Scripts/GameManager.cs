using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;

	public int livesLeft = 3;
	public UnityEngine.UI.Text DispayLivesCount;
	public UnityEngine.UI.Text DispayTime;
	public float timerCount {get; set;}

	public bool isRunning = true;

	public float positionPlayer = 0f;
	public float deltaMove = 0.1f;

	public BH_Player BulletHellPlayer;
	public CB_Bar CasseBriquePlayer;



	// Use this for initialization
	void Awake () {
		timerCount = 0;
		instance = this;
		//StartCoroutine(TimeCount());
		BulletHellPlayer = FindObjectOfType<BH_Player>();
		CasseBriquePlayer = FindObjectOfType<CB_Bar>();
	}

	IEnumerator TimeCount() {
		while (isRunning) { 
			yield return new WaitForSeconds(1f);
			timerCount++;
			DispayTime.text = (/*(int)*/timerCount).ToString();
		}

	}
	
	// Update is called once per frame
	void Update () {
		timerCount+=Time.deltaTime;
		DispayTime.text = (/*(int)*/timerCount).ToString("0000.00");

		if(Input.GetKey(KeyCode.R))
			Application.LoadLevel(0);
	}

	public void FixedUpdate() {
		if (Input.GetKey(KeyCode.Q) && positionPlayer > -1f) {
			positionPlayer-=  deltaMove;
			setPositionPlayerMiniGames();
		} else if (Input.GetKey(KeyCode.D) && positionPlayer < 1) {
			positionPlayer += deltaMove;
			setPositionPlayerMiniGames();
		}
	}

	public void setPositionPlayerMiniGames() {
		BulletHellPlayer.setPositionPlayer(positionPlayer);
		CasseBriquePlayer.SetPosition(positionPlayer);
	}

	public void removeLife(){
		if (livesLeft == 0)
			GameOver();
		else
			livesLeft--;
		DispayLivesCount.text = livesLeft.ToString();
		
	}

	private void GameOver() {
		throw new System.NotImplementedException();
	}
}
