using UnityEngine;
using System.Collections;

public class BH_Enemy : MonoBehaviour {
	
	public bool changeTrajectory = false;
	public Vector3 startPos;
	public Vector3 direction;

	public BH_Player player;
	public float speed { get; set; }
	Vector3 dir;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<BH_Player>();
		dir = player.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(changeTrajectory)
			dir = player.transform.position - this.transform.position;
		this.transform.position = this.transform.position + (dir.normalized * speed);
		if(this.transform.localPosition.x > 10f || this.transform.localPosition.x < -10f
		|| this.transform.localPosition.y > 10f || this.transform.localPosition.y < -10f) {
			Destroy(this.gameObject);
		}
	}

}
