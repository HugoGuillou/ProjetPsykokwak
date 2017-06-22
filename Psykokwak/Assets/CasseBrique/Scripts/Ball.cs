using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Vector3 _velocity;
	public float _speed = 1f;
	public float _maxSpeed = 40f;
	public float _speedInc = 0.1f;
	public float _barDeviation = 2f;

	// Use this for initialization
	void Start () 
	{
	
		_velocity = new Vector3 (1, 1, 0) * _speed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (_velocity * Time.deltaTime);
	}

	void OnCollisionEnter(Collision coll)
	{
		float offset = 0f;

		if (coll.gameObject.tag == "Bar") 
		{
			Transform bar = coll.gameObject.GetComponent<Bar>().transform;

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
		if (coll.gameObject.tag == "PitOfDespair") 
		{
			//TODO
			//GameManager.Lose();
			Debug.Log ("YOU'RE FUCKIND DEAD");
			
		}
	}

}
