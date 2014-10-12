using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {


	public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FireBullet () {
		GameObject bullet = (GameObject) GameObject.Instantiate(bulletPrefab);
		bullet.GetComponent<ChasingBullet>().target = GameObject.Find("Player");
		bullet.transform.position = transform.position;
	}
}
