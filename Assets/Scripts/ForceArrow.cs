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
				GetComponent<LineRenderer>().SetColors ( attractColor, attractColor * 2f );
			} else if (value == ForceKind.REPEL) {
				GetComponent<LineRenderer>().SetColors ( repelColor, repelColor * 2f );
			}
		}
	}

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 s = transform.parent.localScale;
		transform.localScale = new Vector3 ( 1/s.x, 1/s.y, 1/s.z );
	}
}
