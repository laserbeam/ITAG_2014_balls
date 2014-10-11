using UnityEngine;
using System.Collections;

public class ForceArrow : MonoBehaviour {

	private LineRenderer lineRenderer;

	public Color attractColor;
	public Color repelColor;

	private Vector2 forceStorage;
	public Vector2 force {
		get {
			return forceStorage;
		}
		set {
			Debug.Log ("CALLED " + value);
			forceStorage = value;
			lineRenderer.SetPosition ( 1, new Vector3 ( value.x, value.y ));
		}
	}
	public enum ForceKind {
		REPEL,
		ATTRACT
	};
	private ForceKind kindStorage;
	public ForceKind kind {
		get {
			return kindStorage;
		}
		set {
			kindStorage = value;
			if (value == ForceKind.ATTRACT) {
				GetComponent<LineRenderer>().SetColors ( attractColor, Color.white );
			} else if (value == ForceKind.REPEL) {
				GetComponent<LineRenderer>().SetColors ( repelColor, Color.white );
			}
		}
	}

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
