using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pickup : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	GameObject getMouseHoverObject (float range) {
		//vector3 = where we are
		Vector3 position = gameObject.transform.position;
		RaycastHit raycastHit;
		Vector3 target = position + Camera.main.transform.forward * range;
		//if there is a collision
		if (Physics.Linecast (position, target, out raycastHit))
			return raycastHit.collider.gameObject;
		return null;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (getMouseHoverObject (5));
	}
}
