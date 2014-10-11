using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector2 initialForce = new Vector2(0, 0);
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine ( transform.position, transform.position + new Vector3 ( initialForce.x, initialForce.y ));
	}

	void OnMouseDrag () {
		Vector3 t = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Debug.DrawLine ( transform.position, t );
		Vector3 dir = t - transform.position;
		initialForce = new Vector2 ( dir.x, dir.y );
	}

	void OnTriggerEnter2D ( Collider2D coll ) {
		Debug.Log ( coll.gameObject.tag );
		if (coll.gameObject.tag == "Target") {
			GetComponent<Rigidbody2D>().isKinematic = true;
			GetComponent<Animator>().SetTrigger("won");
		}
	}

	void ResetToStart () {
		GetComponent<Animator>().SetBool("won", false);
		Camera.main.GetComponent<Simulation>().ResetSimulation();
		GetComponent<Rigidbody2D>().isKinematic = false;
	}


}
