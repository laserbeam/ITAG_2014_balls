using UnityEngine;
using System.Collections;

public class PhysicsOverlay : MonoBehaviour {

	public GameObject planetUIPrefab;
	private bool enabledStorage = false;
	public bool enabled {
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
		}
		foreach (var obj in GameObject.FindGameObjectsWithTag("Repeller")) {
			GameObject stuff = (GameObject) GameObject.Instantiate ( planetUIPrefab );
			stuff.GetComponent<PlanetUIController>().planet = obj.GetComponent<GravitySource>();
		}
	}

	void EnableOverlay () {
		Debug.Log (camera.cullingMask);
		camera.cullingMask = camera.cullingMask | (1 << LayerMask.NameToLayer ("PhysicsOverlay"));
		Debug.Log (camera.cullingMask);
	}

	void DisableOverlay () {
		Debug.Log (camera.cullingMask);
		camera.cullingMask = camera.cullingMask & (~(1 << LayerMask.NameToLayer ("PhysicsOverlay")));
		Debug.Log (camera.cullingMask);
	}

	// Update is called once per frame
	void Update () {
	
	}

}
