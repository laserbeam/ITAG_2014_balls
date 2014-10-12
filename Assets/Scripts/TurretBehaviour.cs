using UnityEngine;
using System.Collections;

public class TurretBehaviour : MonoBehaviour {

	private LineRenderer lr;
	private Transform head;
	private Transform headRig;
	public float radCircle = 5;
	public int points = 50;
	private GameObject target;
	private bool trackTarget = false;
	public AudioClip fireSound;
	private ParticleSystem charge;

	void Start () {
		lr = transform.GetComponent<LineRenderer>();
		charge = transform.Find("Charge").GetComponent<ParticleSystem>();
		head = transform.Find("HeadRig/Head");
		headRig = transform.Find ("HeadRig");
		DrawCircle();
	}

	void DrawCircle () {
//		int i = 0;
		float theta_scale = 2*Mathf.PI / points;
		float theta = 0;
		for(int i = 0; i <= points; i++)
		{
			// Calculate position of point
			float x = radCircle * Mathf.Cos(theta);
			float y = radCircle * Mathf.Sin(theta);
			
			// Set the position of this point
			Vector3 pos = new Vector3(x, y, 1);
			lr.SetPosition(i, pos);
			theta += theta_scale;
		}
	}

	void OnTriggerEnter2D ( Collider2D coll ) {
		if (coll.gameObject.tag == "Player") {
			target = coll.gameObject;
			audio.Play();
			trackTarget = true;
			head.GetComponent<Animator>().SetTrigger("fire");
			charge.Play();
		}
	}


	// Update is called once per frame
	void Update () {
		if (trackTarget) {
			Vector3 t = target.transform.position;
			t.z = transform.position.z;
			Vector3 dir = t - transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			headRig.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);		
		}
	}
}
