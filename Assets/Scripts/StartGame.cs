using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void StartTheGame () {
		Application.LoadLevel ( "Level2" );
	}

	// Update is called once per frame
	void Update () {
	
	}
}
