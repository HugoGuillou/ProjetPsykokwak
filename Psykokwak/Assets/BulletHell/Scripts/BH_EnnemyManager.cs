using UnityEngine;
using System.Collections;

public class BH_EnnemyManager : MonoBehaviour {

	bool switcher = true;

	public Material ennemyMaterial;
	public Camera cam;
	// Use this for initialization
	void Start () {
	
		ennemyMaterial.color = Color.white;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("k")) 
		{
			switcher = !switcher;
			SwitchColors (switcher);
		}
	}

	public void SwitchColors(bool bVal)
	{
		Color colorSwitch1;
		Color colorSwitch2;
		
		if (bVal) {
			colorSwitch1 = Color.black;
			colorSwitch2 = Color.white;
		} else {
			colorSwitch1 = Color.white;
			colorSwitch2 = Color.black;
		}

		ennemyMaterial.color = colorSwitch1;
		cam.backgroundColor = colorSwitch2;
	}
}
