using UnityEngine;
using System.Collections;

public class ZombieMovement : MonoBehaviour {
	public Vector3 target = Camera.main.gameObject.transform.position;
	private float initialSpawnTime;
	// Use this for initialization
	void Start () {
		initialSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, target, 0.02f);
		if (Time.time - initialSpawnTime > 25)
			Destroy (this.gameObject);
	}

	void OnCollisionEnter(Collision info){
		if (info.collider.name.Equals ("Bomb (1)")) {			
			Time.timeScale = 0;
		}
		else if (info.gameObject.name.Equals ("Bomb")) {
			Destroy (info.gameObject);
			Destroy (this.gameObject);
		}
	}
}
