using UnityEngine;
using System.Collections;

public class GravitySource : MonoBehaviour {

	public static double G = 0.667;

	public float mass = 10;
	public bool attracts = true;
	public float scaleToMassRatio = 10.0f;

	private Vector3 originalPos;
	private Vector3 speed = Vector3.zero;

	// Use this for initialization
	void Start () {
		mass = transform.localScale.x * scaleToMassRatio;
		originalPos = transform.position;
	}

	public Vector2 GetGravityForce ( Vector3 otherPosition, float otherMass ) {
		double r = Vector3.Distance ( transform.position, otherPosition );
		double f = G * otherMass * mass / ( r * r );
		Vector3 dir = (transform.position - otherPosition).normalized * (float)f;
		if (!attracts) {
			dir = -dir;
		}
		return new Vector2 ( dir.x, dir.y );
	}

	public void Reset () {
		speed = Vector3.zero;
		transform.position = originalPos;
	}

	public void Shake ( Vector2 impulse ) {
		speed = new Vector3 ( impulse.x, impulse.y, 0 ) * 4f;
	}

	// Update is called once per frame
	void Update () {
		transform.position = transform.position + speed * Time.deltaTime;
		speed = speed * 0.95f;
	}
}
