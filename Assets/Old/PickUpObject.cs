using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {
	//boolean to determine whether we are carrying an object
	bool carrying;
	GameObject carriedObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//check whether we are carrying an object
		if (carrying) {
			//if carrying, carry the carrying object
			carry (carriedObject);
		} else {
			//if not, maybe we want to pickup some object
			pickUp();
		}
	}

	void carry(GameObject obj) {
		
	}

	void pickUp() {
		//if I press my "E" key, shoot the ray
		if (Input.GetKeyDown (KeyCode.E)) {
			Ray ray = Camera.main.ScreenPointToRay (Vector3.forward);

			RaycastHit raycastHit;
			if(Physics.Raycast(ray, out raycastHit)) {
				Pickable pick = raycastHit.collider.GetComponent<Pickable> ();
				//exists, we're allowed to pick up the object
				if (pick != null) {
					carrying = true;
					carriedObject = pick.gameObject;
				}
			}
		}
	}
}
