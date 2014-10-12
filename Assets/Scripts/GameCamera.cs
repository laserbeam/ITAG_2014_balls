using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	public float sceneSizeW = 8.0f;
	public float sceneSizeH = 4.8f;

	private int _oldWidth;
	private int _oldHeight;

	private float maxOrtographicSize;

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

	Rect GetBounds () {
		Vector3 p1 = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
		Vector3 p2 = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
		float x = Mathf.Min(p1.x, p2.x);
		float y = Mathf.Min(p1.y, p2.y);
		float w = Mathf.Max(p1.x, p2.x) - x;
		float h = Mathf.Max(p1.y, p2.y) - y;
		return new Rect(x, y, w, h);
	}

	public void MoveCamera (Vector3 delta) {
		camera.transform.position -= delta;
		Rect bounds = GetBounds();
		if (bounds.xMin < -sceneSizeW) {
			camera.transform.position = camera.transform.position + new Vector3 ( -sceneSizeW - bounds.xMin, 0, 0 );
		}
		if (bounds.xMax > sceneSizeW) {
			camera.transform.position = camera.transform.position + new Vector3 ( sceneSizeW - bounds.xMax, 0, 0 );
		}
		if (bounds.yMin < -sceneSizeH) {
			camera.transform.position = camera.transform.position + new Vector3 ( 0, -sceneSizeH - bounds.yMin, 0 );
		}
		if (bounds.yMax > sceneSizeH) {
			camera.transform.position = camera.transform.position + new Vector3 ( 0, sceneSizeH - bounds.yMax, 0 );
		}
	}

	void ZoomToFitScene () {
		Debug.Log ( camera.aspect );
		float aspect = Screen.width / (float)Screen.height;
		float w2 = sceneSizeW / aspect;
		camera.orthographicSize = Mathf.Min ( sceneSizeH, w2 );
		maxOrtographicSize = camera.orthographicSize;
		_oldWidth = Screen.width;
		_oldHeight = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		if (Screen.width != _oldWidth || Screen.height != _oldHeight) {
			ZoomToFitScene ();
		}

		float scroll =  Input.GetAxis( "Mouse ScrollWheel" );
		if (scroll != 0) {
			float s = Mathf.Min ( camera.orthographicSize * (1 + scroll), maxOrtographicSize);
			camera.orthographicSize = Mathf.Max ( s, 1 );
			MoveCamera(Vector3.zero);
		}
	}
}
