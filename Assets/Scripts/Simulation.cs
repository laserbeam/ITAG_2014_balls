using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Simulation : MonoBehaviour {

	public GameObject forceArrowPrefab;

	private bool isRunningStorage = false;
	public bool isRunning {
		get {
			return isRunningStorage;
		}
		set {
			if (value) {
				Time.timeScale = 1;
			} else {
				Time.timeScale = 0;
			}
			isRunningStorage = value;
		}
	}

	private GameObject[] attractors;
	private GameObject[] repellers;
	private GameObject player;
	private Dictionary<int, GameObject> forceArrows;

	// Use this for initialization
	void Start () {
		isRunning = false;
		InitObjects ();
	}

	void InitObjects () {
		attractors = GameObject.FindGameObjectsWithTag("Attractor");
		repellers = GameObject.FindGameObjectsWithTag("Repeller");
		player = GameObject.FindGameObjectWithTag("Player");
		forceArrows = new Dictionary<int, GameObject>();
		isRunning = true;

		foreach (GameObject attractor in attractors) {
			GameObject forceArrow = (GameObject) GameObject.Instantiate ( forceArrowPrefab, Vector3.zero, Quaternion.identity );
			forceArrow.transform.parent = player.transform;
			forceArrow.transform.position = player.transform.position;
			forceArrows[attractor.GetInstanceID()] = forceArrow;
			forceArrow.GetComponent<ForceArrow>().kind = ForceArrow.ForceKind.ATTRACT;
		}

		foreach (GameObject repeller in repellers) {
			GameObject forceArrow = (GameObject) GameObject.Instantiate ( forceArrowPrefab, Vector3.zero, Quaternion.identity );
			forceArrow.transform.parent = player.transform;
			forceArrow.transform.position = player.transform.position;
			forceArrows[repeller.GetInstanceID()] = forceArrow;
			forceArrow.GetComponent<ForceArrow>().kind = ForceArrow.ForceKind.REPEL;
		}

	}

	// Update is called once per frame
	void Update () {
		if (isRunning) {
			Rigidbody2D body = player.GetComponent<Rigidbody2D>();
			foreach (GameObject attractor in attractors) {
				Vector2 dir = (attractor.transform.position - player.transform.position).normalized;
				body.AddForce( dir, ForceMode2D.Force );
				ForceArrow arrow = forceArrows[attractor.GetInstanceID()].GetComponent<ForceArrow>();
				arrow.force = dir;
				Vector3 dir3 = new Vector3 ( dir.x, dir.y );
			}

			foreach (GameObject repeller in repellers) {
				Vector2 dir = -(repeller.transform.position - player.transform.position).normalized;
				body.AddForce( dir, ForceMode2D.Force );
				ForceArrow arrow = forceArrows[repeller.GetInstanceID()].GetComponent<ForceArrow>();
				arrow.force = dir;
				Vector3 dir3 = new Vector3 ( dir.x, dir.y );
			}
		}
	}
}
