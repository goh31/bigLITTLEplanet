using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	public GameObject spawned;
	public float minTime = 1.0f;
	public float maxTime = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Invoke ("Spawn", Random.Range (minTime, maxTime));
	}

	void Spawn () {
		Instantiate (spawned);
	}
}
