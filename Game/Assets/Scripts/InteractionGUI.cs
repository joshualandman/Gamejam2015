using UnityEngine;
using System.Collections;

public class InteractionGUI : MonoBehaviour {

	public Texture backgroundImg;
	int backgroundW;
	int backgroundH;
	int backgroundX;
	int backgroundY;
	bool display = false;

	// Use this for initialization
	void Start () {
		backgroundW = Screen.width / 2;
		backgroundH = Screen.height / 2;
		backgroundX = Screen.width / 2 - backgroundW / 2;
		backgroundY = Screen.height / 2 - backgroundH / 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown ("b")) {
			display = !display;
		}
	}

	void DisplayGUI() {
		GUI.DrawTexture (new Rect (backgroundX, backgroundY, backgroundW, backgroundH), backgroundImg);
	}

	void OnGUI() {
		if (display) {
			DisplayGUI ();
		}
	}
}
