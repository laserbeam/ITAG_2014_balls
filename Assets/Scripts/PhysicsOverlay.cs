using UnityEngine;
using System.Collections;

public class PhysicsOverlay : MonoBehaviour {

	public GameObject planetUIPrefab;
	public GameObject ballTrailPrefab;
	public GameObject forceFieldRepelPrefab;
	public GameObject forceFieldAttractPrefab;
	private BallTrail[] allTrails = new BallTrail[4];
	
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
		camera.cullingMask = camera.cullingMask & (~(1 << LayerMask.NameToLayer ("PhysicsOverlay")));
		camera.cullingMask = camera.cullingMask | (1 << LayerMask.NameToLayer ("PauseOverlay"));
	}

	void DisableOverlay () {
		camera.cullingMask = camera.cullingMask | (1 << LayerMask.NameToLayer ("PhysicsOverlay"));
		camera.cullingMask = camera.cullingMask & (~(1 << LayerMask.NameToLayer ("PauseOverlay")));
	}

	public void SpawnTrail () {
		GameObject trailObject = (GameObject) Instantiate ( ballTrailPrefab );
		if (allTrails[3]) {
			Destroy(allTrails[3].gameObject);
		}
		for (int i = 3; i > 0; i--) {
			allTrails[i] = allTrails[i-1];
		}
		BallTrail trail = trailObject.GetComponent<BallTrail>();
		allTrails[0] = trail;
		trail.SetAlpha ( 1 );
		if (allTrails[1]) {
			allTrails[1].isTracing = false;
			allTrails[1].SetAlpha ( 0.6f );
		}
		if (allTrails[2]) {
			allTrails[2].isTracing = false;
			allTrails[2].SetAlpha ( 0.3f );
		}
		if (allTrails[3]) {
			allTrails[3].isTracing = false;
			allTrails[3].SetAlpha ( 0.1f );
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

}
