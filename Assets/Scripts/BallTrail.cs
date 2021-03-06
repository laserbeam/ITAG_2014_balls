﻿using UnityEngine;
using System.Collections;

public class BallTrail : MonoBehaviour {

	private GameObject ball;
	private Vector3 lastPos;
	private float distMade;
	public float dotSpacing = 0.2f;
	public GameObject dotPrefab;
	public bool isTracing = true;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindGameObjectWithTag("Player");
		distMade = 0;
		lastPos = ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (isTracing) {
			Vector3 pos = ball.transform.position;
			float d = Vector3.Distance(pos, lastPos);
			float k = distMade + d;
			while (k > dotSpacing) {
				Vector3 target = Vector3.Lerp ( lastPos, pos, d/dotSpacing );
				GameObject dot = (GameObject) GameObject.Instantiate ( dotPrefab );
				dot.transform.parent = transform;
				dot.transform.position = target;
				distMade -= dotSpacing;
				k = k - dotSpacing;
			}
			distMade += d;
			lastPos = pos;
		}
	}

	public void SetAlpha ( float alpha ) {
		Color c = Color.white;
		c.a = alpha;
		foreach ( SpriteRenderer s in transform.GetComponentsInChildren<SpriteRenderer>()) {
			s.color = c;
		}
	}
	
}
