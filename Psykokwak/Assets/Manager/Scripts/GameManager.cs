using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;

	public int livesLeft = 3;
	public UnityEngine.UI.Text DispayLivesCount;
	public UnityEngine.UI.Text DispayTime;

	public GameObject GameOverPanel;

	public float timerCount {get; set;}

	public bool isRunning = true;

	public float positionPlayer = 0f;
	public float deltaMove = 0.1f;

	public BH_Player BulletHellPlayer;
	public CB_Bar CasseBriquePlayer;
	Camera[] cameras;



	// Use this for initialization
	void Awake () {
		timerCount = 0;
		instance = this;
		//StartCoroutine(TimeCount());
		BulletHellPlayer = FindObjectOfType<BH_Player>();
		CasseBriquePlayer = FindObjectOfType<CB_Bar>();

		cameras = FindObjectsOfType<Camera>();
		StartCoroutine(ChangeCameraPosition());
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
		if (isRunning){
			timerCount+=Time.deltaTime;
			DispayTime.text = (/*(int)*/timerCount).ToString("0000.00");
		}
		if(Input.GetKey(KeyCode.R))
			Restart();
	}

	public void Restart() {
		Debug.Log("restart");
		Application.LoadLevel(1);
	}

	public void Quit() {
		Debug.Log("restart");
		Application.Quit();
	} 


	public void FixedUpdate() {

		if (isRunning)
		if (Input.GetKey(KeyCode.Q) && positionPlayer > -1f) {
			positionPlayer-= deltaMove;
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

	IEnumerator ChangeCameraPosition() {
		yield return new WaitForSeconds(Random.Range(20f, 30f));
		for (int i = 0; i < cameras.Length; i++) {
			Rect rect = cameras[i].rect;
			if (rect.x == 0) {
				rect.x = 0.5f;
			} else {
				rect.x = 0;
			}
			cameras[i].rect = rect;
			Debug.Log(rect);
		}

		StartCoroutine( ChangeCameraPosition());
	}

	public void removeLife(){
		if (livesLeft == 0){
			GameOver();
			DispayLivesCount.text = "";
		} else { 
			livesLeft--;
			DispayLivesCount.text = livesLeft.ToString();
		}
	}

	public void addLife(){
		livesLeft++;
		DispayLivesCount.text = livesLeft.ToString();
	}

	private void GameOver() {
		isRunning = false;
		GameOverPanel.SetActive(true);
	}

}
