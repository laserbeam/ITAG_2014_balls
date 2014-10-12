using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlanetUIController : MonoBehaviour {

	private Text massField;
	private GravitySource planetStorage;
	public GravitySource planet{
		get {
			return planetStorage;
		}
		set {
			planetStorage = value;
			SetPlanet ();
		}
	}

	// Use this for initialization
	void Start () {
		massField = transform.Find("FGCanvas/MassText").GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetPlanet() {
		massField = transform.Find("FGCanvas/MassText").GetComponent<Text>();
		massField.text = "Mass\n" + planetStorage.mass;
		Transform ptransform = planetStorage.transform;
		transform.position = ptransform.position;
		float s = ptransform.localScale.x;
		transform.Find("BGCanvas/BG").localScale = ptransform.localScale;
		transform.Find("FGCanvas").GetComponent<RectTransform>().sizeDelta = new Vector2(s, s);
	}
}
