using UnityEngine;
using System.Collections;

public class BallTrail : MonoBehaviour {

	private GameObject ball;
	private Vector3 lastPos;
	private float distMade;
	public float dotSpacing = 0.2f;
	public GameObject dotPrefab;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindGameObjectWithTag("Player");
		distMade = 0;
		lastPos = ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = ball.transform.position;
		float d = Vector3.Distance(pos, lastPos);
		if (distMade + d > dotSpacing) {
			Vector3 target = Vector3.Lerp ( lastPos, pos, d/dotSpacing );
			GameObject dot = (GameObject) GameObject.Instantiate ( dotPrefab );
			dot.transform.parent = transform;
			dot.transform.position = target;
			distMade -= dotSpacing;
		}
		distMade += d;
		lastPos = pos;
	}
}
