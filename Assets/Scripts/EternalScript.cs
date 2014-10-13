using UnityEngine;
using System.Collections;

public class EternalScript : MonoBehaviour {

	private static EternalScript instance;
	
	public static EternalScript GetInstance() {
		return instance;
	}
	
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
