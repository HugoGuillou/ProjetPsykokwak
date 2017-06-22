﻿using UnityEngine;
using System.Collections;

public class CB_Bar : MonoBehaviour {

	private Vector3 _velocity;
	public float _speed = 0.1f;
	private bool blockedRight;
	private bool blockedLeft;

	// Use this for initialization
	void Start () {
	

	}

	public void SetPosition(float fVal)
	{
		float xAxis = fVal * 7;
		Debug.Log (xAxis);
		//_velocity = new Vector3 (xAxis, 0, 0) * _speed;
		//transform.Translate (_velocity * Time.deltaTime);

		Vector3 pos = transform.localPosition;
		pos.x = xAxis;
		transform.localPosition = pos;
	
	}

	// Update is called once per frame
	void Update () {
/*
		float xAxis = Input.GetAxis ("CB_Horizontal");

		if ((xAxis > 0 && blockedRight) || 
		    (xAxis < 0 && blockedLeft)) 
		{
			return;
		}

		_velocity = new Vector3 (xAxis, 0, 0) * _speed;

		transform.Translate (_velocity * Time.deltaTime);
*/
		
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "CB_LBound") {
			blockedLeft = true;
		} else if (coll.gameObject.tag == "CB_RBound") {
			blockedRight = true;
		}
	}

	void OnCollisionExit(Collision coll)
	{
		if (coll.gameObject.tag == "CB_LBound") {
			blockedLeft = false;
		} else if (coll.gameObject.tag == "CB_RBound") {
			blockedRight = false;
		}
	}

}
