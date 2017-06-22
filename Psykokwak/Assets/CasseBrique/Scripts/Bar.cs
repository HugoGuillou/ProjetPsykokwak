using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour {

	private Vector3 _velocity;
	public float _speed = 0.1f;
	private bool blockedRight;
	private bool blockedLeft;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {

		float xAxis = Input.GetAxis ("CB_Horizontal");

		if ((xAxis > 0 && blockedRight) || 
		    (xAxis < 0 && blockedLeft)) 
		{
			return;
		}

		_velocity = new Vector3 (xAxis, 0, 0) * _speed;

		transform.Translate (_velocity * Time.deltaTime);
		
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "LBound") {
			blockedLeft = true;
		} else if (coll.gameObject.tag == "RBound") {
			blockedRight = true;
		}
	}

	void OnCollisionExit(Collision coll)
	{
		if (coll.gameObject.tag == "LBound") {
			blockedLeft = false;
		} else if (coll.gameObject.tag == "RBound") {
			blockedRight = false;
		}
	}

}
