using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width / 3 - Screen.width / 10, Screen.height * 0.8f, Screen.width / 5, Screen.height / 10), "Continue?")) {
			Application.LoadLevel ("Game");
		}

		if (GUI.Button (new Rect ((Screen.width / 3 * 2) - Screen.width / 10, Screen.height * 0.8f, Screen.width / 5, Screen.height / 10), "Quit.")) {
			Application.Quit();
		}
	}
}
