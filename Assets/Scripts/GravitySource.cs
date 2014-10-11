using UnityEngine;
using System.Collections;

public class GravitySource : MonoBehaviour {

	public static double G = 0.667;

	public float mass = 10;
	public bool attracts = true;

	// Use this for initialization
	void Start () {
	
	}

	public Vector2 GetGravityForce ( Vector3 otherPosition, float otherMass ) {
		double r = Vector3.Distance ( transform.position, otherPosition );
		double f = G * otherMass * mass / ( r * r );
		Debug.Log ( f );
		Vector3 dir = (transform.position - otherPosition).normalized * (float)f;
		if (!attracts) {
			dir = -dir;
		}
		return new Vector2 ( dir.x, dir.y );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
