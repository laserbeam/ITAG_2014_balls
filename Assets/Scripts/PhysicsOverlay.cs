using UnityEngine;
using System.Collections;

public class PhysicsOverlay : MonoBehaviour {

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
