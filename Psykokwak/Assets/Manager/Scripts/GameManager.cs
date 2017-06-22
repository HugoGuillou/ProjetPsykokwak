using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;

	public int livesLeft = 3;
	public UnityEngine.UI.Text DispayLivesCount;
	public UnityEngine.UI.Text DispayTime;
	public float timerCount {get; set;}

	public bool isRunning = true;

	// Use this for initialization
	void Awake () {
		timerCount = 0;
		instance = this;
		//StartCoroutine(TimeCount());
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
