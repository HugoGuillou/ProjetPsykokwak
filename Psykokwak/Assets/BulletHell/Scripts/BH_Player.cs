using UnityEngine;
using System.Collections;

public class BH_Player : MonoBehaviour {

	public Vector2 limits;

	Vector3 prevPos = Vector3.zero;
	Rigidbody rb;

	//bool canMove
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.Q) && this.transform.localPosition.x > -limits.x) { 
			prevPos = this.transform.position;
			this.transform.position = this.transform.position + new Vector3(-0.15f, 0, 0);
		} else if (Input.GetKey(KeyCode.D) && this.transform.localPosition.x < limits.x) { 
			prevPos = this.transform.position;
			this.transform.position = this.transform.position + new Vector3(0.15f, 0, 0);
		}
	}

	void OnCollisionEnter(Collision c) {
		Debug.Log(c.collider.name);
	}

	void OnTriggerEnter(Collider c) {
		Debug.Log("trigger " + c.name, c);
	}
}
