using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class BoxMoves : MonoBehaviour, IGvrGazeResponder {
	private bool triggered;
	private bool gazedAt;
	private Vector3 gyroRead;
	// Use this for initialization
	void Start () {
		this.triggered = false;
		//this.gameObject.GetComponent<ParticleSystem> ().enableEmission = false;
		GetComponent<Renderer>().material.color = Color.green;
		this.gameObject.GetComponent<ParticleSystem>().Stop();
	}
	
	// Update is called once per frame
	void Update () {	
		GvrViewer.Instance.UpdateState();
		if (GvrViewer.Instance.BackButtonPressed) {
			Application.Quit();
		}
	}

	public void SetGazedAt(bool b) {
		this.gazedAt = b;
	}

	public void SetTriggered(bool b) {
		this.triggered = b;
	}

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
		Debug.Log("gaze enter");
		this.SetGazedAt(true);
		GetComponent<Renderer>().material.color = Color.green;
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		Debug.Log ("gaze exit");
		this.SetGazedAt(false);
		this.SetTriggered(false);
		this.gameObject.GetComponent<ParticleSystem> ().Stop ();
		GetComponent<Renderer>().material.color = Color.red;
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		if (gazedAt) {
			this.SetTriggered (true);
			//this.gameObject.GetComponent<ParticleSystem> ().enableEmission = true;
			this.gameObject.GetComponent<ParticleSystem>().Play(); //our lord
		} else {
			this.SetTriggered(false);
			this.gameObject.GetComponent<ParticleSystem> ().Stop ();
		}
	}
}
