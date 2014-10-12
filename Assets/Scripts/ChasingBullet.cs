using UnityEngine;
using System.Collections;

public class ChasingBullet : MonoBehaviour {

	public float speed = 2.0f;
	public float accel = 2.0f;
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			Vector3 dir = (target.transform.position - transform.position).normalized;
			speed = speed + accel * Time.deltaTime;
			transform.position = transform.position + dir * speed * Time.deltaTime;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}

	void OnTriggerEnter2D ( Collider2D coll ) {
		if (coll.gameObject == target) {
			target.GetComponent<Ball>().Kill();
			Destroy(this);
		}
	}
}
