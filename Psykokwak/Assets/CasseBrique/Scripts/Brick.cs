using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public float height;
	
	CB_GameManager gameManager;

	void Awake()
	{
		Mesh mesh = GetComponent<MeshFilter> ().mesh;
		Bounds bounds = mesh.bounds;

		gameManager = FindObjectOfType<CB_GameManager> ();

		//height = transform.lossyScale.y;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionExit(Collision coll)
	{
		if (coll.gameObject.tag == "CB_Ball") 
		{
			gameManager.destroyBrick(this);
		}
	}
}
