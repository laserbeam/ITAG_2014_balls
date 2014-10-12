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
//		GetComponent<Rigidbody2D>().isKinematic = true;
//		GetComponent<CircleCollider2D>().enabled = false;
//		GetComponent<Animator>().SetTrigger("won");
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
			GetComponent<Rigidbody2D>().isKinematic = true;
			GetComponent<CircleCollider2D>().enabled = false;
			GetComponent<Animator>().SetTrigger("won");
		}
	}

	void OnCollisionEnter2D ( Collision2D coll ) {
		string tag = coll.gameObject.tag;
		if (tag == "Enemy" || tag == "Repeller" || tag == "Attractor") {
			Kill();
		}
	}

	public void Kill() {
		GetComponent<Rigidbody2D>().isKinematic = true;
		GetComponent<CircleCollider2D>().enabled = false;
		GetComponent<Animator>().SetTrigger("death");
	}

	void ResetToStart () {
		Debug.Log ( "reset was called." );
		GetComponent<Animator>().SetTrigger("reset");
		Camera.main.GetComponent<Simulation>().ResetSimulation();
		GetComponent<Rigidbody2D>().isKinematic = false;
		GetComponent<CircleCollider2D>().enabled = true;
	}


}
