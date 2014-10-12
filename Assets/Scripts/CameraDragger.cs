using UnityEngine;
using System.Collections;

public class CameraDragger : MonoBehaviour {

	private GameCamera gameCamera;
	private Vector3 lastPos;
	private bool mousePressed = false;

	// Use this for initialization
	void Start () {
		gameCamera = Camera.main.GetComponent<GameCamera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (mousePressed) {
			Vector3 p = Input.mousePosition;
			Vector3 scaledDelta = Camera.main.ScreenToWorldPoint(p-lastPos) - Camera.main.ScreenToWorldPoint(Vector3.zero);
			gameCamera.MoveCamera ( scaledDelta );
			lastPos = p;
		}
	}

	void OnMouseDown () {
		mousePressed = true;
		lastPos = Input.mousePosition;
	}

//	void OnMouseDrag () {
//
//	}

	void OnMouseUp () {
		mousePressed = false;
	}
}
