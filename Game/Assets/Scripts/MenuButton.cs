using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	public enum ButtonType { PlayGame , EndGame };

	public ButtonType type;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnMouseDown() {
		switch(type) 
		{
			case ButtonType.PlayGame:
				Application.LoadLevel ("Game");
				break;
			case ButtonType.EndGame:
				Application.Quit();
				break;
		}
	}
}
