using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	int rowLength;
	int rowHeight;
	int xPos;
	int yPos;

	// Use this for initialization
	void Start () {
		rowLength = Screen.width / 5;
		rowHeight = Screen.height / 15;
		xPos = (Screen.width - rowLength) / 2;
		yPos = (int)(Screen.height / 4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		for (int i = 0; i < MyConstants.NUM_ENDINGS; i++) {
			if(MyConstants.ENDINGS_UNLOCKED[i]) {
				GUI.TextArea(new Rect(xPos, yPos + (rowHeight * i), rowLength, rowHeight), MyConstants.ENDINGS[i]);
			}
			else {
				GUI.TextArea(new Rect(xPos, yPos + (rowHeight * i), rowLength, rowHeight), "Locked");
			}
		}



		if (GUI.Button (new Rect (Screen.width / 3 - Screen.width / 10, Screen.height * 0.8f, Screen.width / 5, Screen.height / 10), "Continue?")) {
			Application.LoadLevel ("Game");
		}

		if (GUI.Button (new Rect ((Screen.width / 3 * 2) - Screen.width / 10, Screen.height * 0.8f, Screen.width / 5, Screen.height / 10), "Quit.")) {
			Application.Quit();
		}
	}
}