using UnityEngine;
using System.Collections;

public class CB_Ball : MonoBehaviour {

	private Vector3 _velocity;
	public float _speed = 1f;
	public float _maxSpeed = 40f;
	public float _speedInc = 0.1f;
	public float _barDeviation = 50;

	private float initSpeed;
	private Vector3 initPos;
	private Quaternion initRot;

	public float respawnTime = 3;
	private float respawnTimeLeft;
	private bool respawnTimer = true;

	// Use this for initialization
	void Start () 
	{
		initPos = transform.position;
		initRot = transform.rotation;
		initSpeed = _speed;

		_velocity = new Vector3 (1, 1, 0) * _speed;

		respawnTimeLeft = respawnTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (respawnTimer) 
		{
			respawnTimeLeft -= Time.deltaTime;
			if (respawnTimeLeft < 0) 
			{
				respawnTimeLeft = respawnTime;
				respawnTimer = false;
			}
			return;
		}

		transform.Translate (_velocity * Time.deltaTime);
	}

	void OnCollisionEnter(Collision coll)
	{
		float offset = 0f;

		if (coll.gameObject.tag == "CB_Bar") 
		{
			Transform bar = coll.gameObject.GetComponent<CB_Bar>().transform;

			float posFromBar = ((transform.position.x - bar.position.x) / bar.localScale.x) * 2;
			offset = posFromBar * _barDeviation;

		}
		_speed += _speedInc;

		if (_speed > _maxSpeed) 
		{
			_speed = _maxSpeed;
		}
			
		Vector3 dir = Vector3.Reflect(_velocity, coll.contacts[0].normal); 

		dir = new Vector3 (dir.x + offset, dir.y, 0);

		_velocity = dir.normalized * _speed;
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "CB_PitOfDespair") 
		{
			//TODO
			GameManager.instance.removeLife();
			ResetBall();
			Debug.Log ("YOU'RE FUCKIND DEAD");
			
		}
	}

	void ResetBall()
	{
		GetComponent<Rigidbody> ().velocity = Vector3.zero;

		transform.position = initPos;
		transform.rotation = initRot;

		_speed = initSpeed;
		_velocity = new Vector3 (1, 1, 0).normalized * _speed;

		respawnTimer = true;
	}



}
