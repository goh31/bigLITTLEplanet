using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	public GameObject spawned;
	public float minTime = 1.0f;
	public float maxTime = 5.0f;
	public float nextSpawnTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Time.time = current time
		//If we have passed the point when we want to spawn
		if (Time.time > nextSpawnTime) {
			Instantiate(spawned, transform.position, transform.rotation);	
			nextSpawnTime = Time.time + Random.Range(minTime, maxTime);
		}
	}
}
