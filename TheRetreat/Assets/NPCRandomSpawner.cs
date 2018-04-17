using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRandomSpawner : MonoBehaviour {

	public GameObject boiToSpawn;
	public float RandomSpawnRadius = 30f;
	public float numberOfBois = 30f;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < numberOfBois; i++) {
			Vector2 spawnPoint = Random.insideUnitCircle * RandomSpawnRadius;
			Vector3 randRot = new Vector3 (0f, Random.Range (0f, 360f), 0f);

			GameObject boi = Instantiate (boiToSpawn, new Vector3(spawnPoint.x, transform.position.y, spawnPoint.y) + transform.position, 
				Quaternion.Euler (randRot));
			boi.transform.parent = this.transform;
		}
	}
}