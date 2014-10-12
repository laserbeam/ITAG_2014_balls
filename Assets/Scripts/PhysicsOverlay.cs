using UnityEngine;
using System.Collections;

public class PhysicsOverlay : MonoBehaviour {

	public GameObject planetUIPrefab;
	public GameObject ballTrailPrefab;
	public GameObject forceFieldRepelPrefab;
	public GameObject forceFieldAttractPrefab;

	private bool enabledStorage = true;
	public bool isEnabled {
		get {
			return enabledStorage;
		}
		set {
			enabledStorage = value;
			if (value) {
				EnableOverlay();
			} else {
				DisableOverlay();
			}
		}
	}

	// Use this for initialization
	void Start () {
		foreach (var obj in GameObject.FindGameObjectsWithTag("Attractor")) {
			GameObject stuff = (GameObject) GameObject.Instantiate ( planetUIPrefab );
			stuff.GetComponent<PlanetUIController>().planet = obj.GetComponent<GravitySource>();
			stuff = (GameObject) GameObject.Instantiate ( forceFieldAttractPrefab );
			stuff.transform.position = obj.transform.position + Vector3.back;
		}
		foreach (var obj in GameObject.FindGameObjectsWithTag("Repeller")) {
			GameObject stuff = (GameObject) GameObject.Instantiate ( planetUIPrefab );
			stuff.GetComponent<PlanetUIController>().planet = obj.GetComponent<GravitySource>();
			stuff = (GameObject) GameObject.Instantiate ( forceFieldRepelPrefab );
			stuff.transform.position = obj.transform.position + Vector3.back;
		}
	}

	void EnableOverlay () {
		camera.cullingMask = camera.cullingMask | (1 << LayerMask.NameToLayer ("PhysicsOverlay"));
	}

	void DisableOverlay () {
		camera.cullingMask = camera.cullingMask & (~(1 << LayerMask.NameToLayer ("PhysicsOverlay")));
	}

	// Update is called once per frame
	void Update () {
	
	}

}
