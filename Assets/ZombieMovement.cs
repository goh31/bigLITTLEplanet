using UnityEngine;
using System.Collections;

public class ZombieMovement : MonoBehaviour {
	public Vector3 target = Camera.main.gameObject.transform.position;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, target, 0.03f);
	}
}
