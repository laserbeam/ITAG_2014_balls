using UnityEngine;
using System.Collections;

public class Simulation : MonoBehaviour {

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

	// Use this for initialization
	void Start () {
		isRunning = false;
		InitObjects ();
	}

	void InitObjects () {
		attractors = GameObject.FindGameObjectsWithTag("Attractor");
		repellers = GameObject.FindGameObjectsWithTag("Repeller");
		player = GameObject.FindGameObjectWithTag("Player");
		isRunning = true;
	}

	// Update is called once per frame
	void Update () {
		if (isRunning) {
			Rigidbody2D body = player.GetComponent<Rigidbody2D>();
			foreach (GameObject attractor in attractors) {
				Vector2 dir = (attractor.transform.position - player.transform.position).normalized;
				body.AddForce( dir, ForceMode2D.Force );
				Vector3 dir3 = new Vector3 ( dir.x, dir.y );
				Debug.DrawLine ( player.transform.position, player.transform.position + dir3, Color.blue );
			}

			foreach (GameObject repeller in repellers) {
				Vector2 dir = -(repeller.transform.position - player.transform.position).normalized;
				body.AddForce( dir, ForceMode2D.Force );
				Vector3 dir3 = new Vector3 ( dir.x, dir.y );
				Debug.DrawLine ( player.transform.position, player.transform.position + dir3, Color.red );
			}
		}
	}
}
