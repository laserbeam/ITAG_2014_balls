using UnityEngine;
using System.Collections;

public class SpringController : MonoBehaviour {

	private ParticleSystem ps;

	// Use this for initialization
	void Start () {
		ps = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D ( Collision2D coll ) {
		if (coll.gameObject.tag == "Player") {
			Animator[] animators = GetComponentsInChildren<Animator>();
			foreach ( Animator anim in animators ) {
				anim.SetTrigger("fire");
			}
			audio.Play();
			Vector2 point = coll.contacts[0].point;
			ps.transform.position = new Vector3 ( point.x, point.y, 0 );
			ps.Play();
		}
	}
}
