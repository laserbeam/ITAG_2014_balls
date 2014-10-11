using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	public float sceneSizeW = 8.0f;
	public float sceneSizeH = 4.8f;

	private int _oldWidth;
	private int _oldHeight;
	
	// Use this for initialization
	void Start () {
		GameObject bg = GameObject.FindGameObjectWithTag("Background");
		Sprite bgsprite = bg.GetComponent<SpriteRenderer>().sprite;
		Vector3 border = bgsprite.bounds.size;
		float s1 = sceneSizeW/border[0];
		float s2 = sceneSizeH/border[1];
		s1 = Mathf.Max ( s1, s2 ) * 2;
		bg.transform.localScale = new Vector3 ( s1, s1, 0 );
		ZoomToFitScene ();
	}

	void ZoomToFitScene () {
		Debug.Log ( camera.aspect );
		float aspect = Screen.width / (float)Screen.height;
		float w2 = sceneSizeW / aspect;
		camera.orthographicSize = Mathf.Min ( sceneSizeH, w2 );
		_oldWidth = Screen.width;
		_oldHeight = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		if (Screen.width != _oldWidth || Screen.height != _oldHeight) {
			ZoomToFitScene ();
		}
	}
}
