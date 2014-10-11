using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	Vector2 initialForce = new Vector2(0, 0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		GameObject[] attractors = GameObject.FindGameObjectsWithTag("Attractor");
		GameObject[] repellers = GameObject.FindGameObjectsWithTag("Repeller");

		foreach (GameObject attractor in attractors) {
			Debug.DrawLine ( transform.position, attractor.transform.position, Color.blue );
		}

		foreach (GameObject repeller in repellers) {
			Debug.DrawLine ( transform.position, repeller.transform.position, Color.red );
		}

	}
}
