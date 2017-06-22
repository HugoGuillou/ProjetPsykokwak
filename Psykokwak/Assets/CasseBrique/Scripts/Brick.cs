using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public float height;

	void Awake()
	{
		//Mesh mesh = GetComponent<MeshFilter> ();
		height = transform.lossyScale.y;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "CB_Ball") 
		{
			Destroy(gameObject);
		}
	}
}
