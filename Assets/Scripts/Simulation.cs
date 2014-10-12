﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Simulation : MonoBehaviour {

	public GameObject forceArrowPrefab;

	private PhysicsOverlay physicsOverlay;

	private bool isRunningStorage = false;
	public bool isRunning {
		get {
			return isRunningStorage;
		}
		set {
			isRunningStorage = value;
			if (value) {
				physicsOverlay.isEnabled = false;
				StartSimulation ();
			} else {
				physicsOverlay.isEnabled = true;
			}
		}
	}
	public bool isReset = true;

	private GameObject[] attractors;
	private GameObject[] repellers;
	private GameObject player;
	private Dictionary<int, GameObject> forceArrows;
	private Vector3 initialPlayerPosition;
	private Quaternion initialPlayerRotation;
	private Vector3 initialPlayerScale;
	// Use this for initialization
	void Start () {
		physicsOverlay = GetComponent<PhysicsOverlay>();
		isRunning = false;
		InitObjects ();
	}

	void StartSimulation () {
		if (isReset) {
			Rigidbody2D body = player.GetComponent<Rigidbody2D>();
			body.isKinematic = false;
			body.AddForce ( player.GetComponent<Ball>().initialForce, ForceMode2D.Impulse );
			isReset = false;
		}
	}

	public void ResetSimulation () {
		isRunning = false;
		isReset = true;
		player.transform.position = initialPlayerPosition;
		player.transform.rotation = initialPlayerRotation;
		player.transform.localScale = initialPlayerScale;
		TrailRenderer tr = player.GetComponent<TrailRenderer>();
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Bullet")) {
			Destroy(obj);	
		}
	}

	void InitObjects () {
		attractors = GameObject.FindGameObjectsWithTag("Attractor");
		repellers = GameObject.FindGameObjectsWithTag("Repeller");
		player = GameObject.FindGameObjectWithTag("Player");
//		initialPlayerTransform = new Transform();
		initialPlayerPosition = player.transform.position;
		initialPlayerRotation = player.transform.rotation;
		initialPlayerScale = player.transform.localScale;
		forceArrows = new Dictionary<int, GameObject>();
//		camera.cullingMask = ~(1 << LayerMask.NameToLayer ("PhysicsOverlay"));

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
			float mass = body.mass;
			foreach (GameObject attractor in attractors) {
				Vector2 dir = attractor.GetComponent<GravitySource>().GetGravityForce( player.transform.position, mass );
				body.AddForce( dir, ForceMode2D.Force );
				ForceArrow arrow = forceArrows[attractor.GetInstanceID()].GetComponent<ForceArrow>();
				arrow.force = dir;
//				Vector3 dir3 = new Vector3 ( dir.x, dir.y );
			}

			foreach (GameObject repeller in repellers) {
				Vector2 dir = repeller.GetComponent<GravitySource>().GetGravityForce( player.transform.position, mass );
				body.AddForce( dir, ForceMode2D.Force );
				ForceArrow arrow = forceArrows[repeller.GetInstanceID()].GetComponent<ForceArrow>();
				arrow.force = dir;
//				Vector3 dir3 = new Vector3 ( dir.x, dir.y );
			}
		}
	}
}
