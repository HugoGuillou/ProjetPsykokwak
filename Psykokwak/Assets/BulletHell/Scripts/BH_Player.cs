using UnityEngine;
using System.Collections;

public class BH_Player : MonoBehaviour {

	public float limitPos;

	Vector3 prevPos = Vector3.zero;
	Rigidbody rb;
	Renderer renderer;
	Coroutine clignotteCoroutine;
	Color playerColor;
	bool invincibility = false;

	//bool canMove
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
		renderer = this.GetComponent<Renderer>();
		playerColor = renderer.material.color;
	}
	
	// Update is called once per frame
	/*void FixedUpdate () {
		if (Input.GetKey(KeyCode.Q) && this.transform.localPosition.x > -limits.x) { 
			prevPos = this.transform.position;
			this.transform.position = this.transform.position + new Vector3(-0.15f, 0, 0);
		} else if (Input.GetKey(KeyCode.D) && this.transform.localPosition.x < limits.x) { 
			prevPos = this.transform.position;
			this.transform.position = this.transform.position + new Vector3(0.15f, 0, 0);
		}
	}*/

	void OnTriggerEnter(Collider c) {
		if (invincibility)
			return;

		if(clignotteCoroutine != null)
			StopCoroutine(clignotteCoroutine);
		clignotteCoroutine = StartCoroutine(Clignotte());
		invincibility = true;
		GameManager.instance.removeLife();
	}

	IEnumerator Clignotte() {

		for (int i = 0; i < 6; i++) {
			if (i % 2 == 0) {
				renderer.material.color = Color.grey;
			} else {
				renderer.material.color = playerColor;
			}
			yield return new WaitForSeconds(0.15f);	
		}
		invincibility = false;
	}

	public void setPositionPlayer(float positionPlayer) {
		this.transform.localPosition =
			new Vector3(positionPlayer * limitPos, this.transform.position.y, this.transform.position.z);
	}


}
