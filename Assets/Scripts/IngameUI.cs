using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class IngameUI : MonoBehaviour {

	private RectTransform playButton;
	private RectTransform pauseButton;

	// Use this for initialization
	void Start () {
		playButton = (RectTransform) transform.Find("PlayButton");
		pauseButton = (RectTransform) transform.Find("PauseButton");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SwapPlayPause () {
		Vector3 temp = playButton.position;
		playButton.position = pauseButton.position;
		pauseButton.position = temp;
	}

	public void SetPlayVisible () {
		if (pauseButton.position.y < playButton.position.y) {
			SwapPlayPause();
		}
	}
}
