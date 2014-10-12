using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector2 initialForce = new Vector2(0, 0);
	public float initialForceMult = 10.0f;

	private CircleCollider2D collider;
	private Rigidbody2D body;
	private Animator animator;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		collider = GetComponent<CircleCollider2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine ( transform.position, transform.position + new Vector3 ( initialForce.x/initialForceMult, initialForce.y/initialForceMult ));
	}

	void OnMouseDrag () {
		Vector3 t = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Debug.DrawLine ( transform.position, t );
		Vector3 dir = t - transform.position;
		initialForce = new Vector2 ( dir.x, dir.y ) * initialForceMult;
	}

	void OnTriggerEnter2D ( Collider2D coll ) {
		if (coll.gameObject.tag == "Target") {
			body.isKinematic = true;
			collider.enabled = false;
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
		body.isKinematic = true;
		collider.enabled = false;
		animator.SetTrigger("death");
	}

	void ResetToStart () {
		Debug.Log ( "reset was called." );
		Camera.main.GetComponent<Simulation>().ResetSimulation();
		body.isKinematic = false;
		collider.enabled = true;
		animator.SetTrigger("reset");
	}


}
