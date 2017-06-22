using UnityEngine;
using System.Collections;

public class BH_Spawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject bonusPrefab;
	public Transform EnemyParent;
	public float spawnSeconds = 1f; 
	public float spawnTimeReduction = 0.995f;

	public float enemySpeed = 0.1f;
	public int count = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnCoroutine() {
		GameObject enemy;
		while (true) {
			yield return new WaitForSeconds(spawnSeconds);
			count++;
			if (count%25 == 24)
				enemy = (GameObject)Instantiate(bonusPrefab);
			else 
				enemy = (GameObject)Instantiate(enemyPrefab);
			enemy.transform.position = this.transform.position + new Vector3(Random.Range(-5f, 5f), 0f, 0f);
			enemy.transform.parent = EnemyParent;
			enemy.GetComponent<BH_Enemy>().speed = enemySpeed;
			if (spawnSeconds > 0.01f)
			spawnSeconds*=0.99f;
		}

	}
}
