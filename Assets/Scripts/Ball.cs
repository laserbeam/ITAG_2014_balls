using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector2 initialForce = new Vector2(0, 0);
	public float initialForceMult = 10.0f;
	public float maxInitialForceVector = 50.0f;

	private Rigidbody2D body;
	private Animator animator;
	private ForceArrow initialForceArrow;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		initialForceArrow = GetComponentInChildren<ForceArrow>();
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.DrawLine ( transform.position, transform.position + new Vector3 ( initialForce.x/initialForceMult, initialForce.y/initialForceMult ));
	}

	void OnMouseDrag () {
		Vector3 t = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 dir = t - transform.position;
		initialForce = new Vector2 ( dir.x, dir.y ) * initialForceMult;
		if (initialForce.magnitude > maxInitialForceVector) {
			initialForce = initialForce.normalized * maxInitialForceVector;
		}
		initialForceArrow.force = initialForce * 0.1f;
	}

	void OnTriggerEnter2D ( Collider2D coll ) {
		if (coll.gameObject.tag == "Target") {
			body.simulated = false;
			animator.SetTrigger("won");
		}
	}

	void OnCollisionEnter2D ( Collision2D coll ) {
		string tag = coll.gameObject.tag;
		if (tag == "Enemy" || tag == "Repeller" || tag == "Attractor") {
			Kill();
		}
	}

	public void Kill() {
		body.velocity = Vector2.zero;
		body.simulated = false;
		animator.SetTrigger("death");
	}

	public void ResetSimulation () {
		Debug.Log ( Camera.main.GetComponent<Simulation> ());
		Camera.main.GetComponent<Simulation>().ResetSimulation();
	}

	public void ResetToStart () {
		body.simulated = true;
		body.isKinematic = true;
		body.velocity = Vector2.zero;
		animator.SetTrigger("reset");
	}

	public void Freeze() {
		body.simulated = false;
	}

	public void Unfreeze() {
		body.simulated = false;
	}
}
