using UnityEngine;
using System.Collections;

public class Initialize : MonoBehaviour {

	// UI Textures
	public Texture portraitImg;
	public Texture inventoryImg;
	public Texture healthbarBackground;

	// Inventory Variables
	bool inventoryOpen = false;
	int selGridInt = 0;
	Texture[] inventoryTextures = new Texture[8];

	// Health/Stamina Bar Variables
	int healthbarLength = 100;
	int healthbarMaxLength = 100;
	int staminabarLength = 100;
	int staminabarMaxLength = 100;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 8; i++) {
			inventoryTextures[i] = inventoryImg;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI() {
		// Player portrait
		GUI.DrawTexture (new Rect (10, 10, Screen.width/15, Screen.width/15), portraitImg);
		// Health Bar
		GUI.DrawTexture (new Rect (10 + Screen.width / 15 + 5, 10 , Screen.width / 5, Screen.height / 70), healthbarBackground);
		// Inventory Button
		if (GUI.Button (new Rect (Screen.width - Screen.width / 15, Screen.height - Screen.width / 15, Screen.width / 15, Screen.width / 15), inventoryImg)) {
			inventoryOpen = !inventoryOpen;
		}

		if (inventoryOpen) {
			GUI.DrawTexture (new Rect (Screen.width - Screen.width / 5, Screen.height - Screen.height / 3 - Screen.width / 15, Screen.width / 5, Screen.height / 3), portraitImg);
			selGridInt = GUI.SelectionGrid (new Rect (Screen.width - Screen.width / 5, Screen.height - Screen.height / 3 - Screen.width / 15, Screen.width / 5, Screen.height / 3), selGridInt, inventoryTextures, 2);
		} 
		else {
			selGridInt = -1;
		}
	}
	
}
