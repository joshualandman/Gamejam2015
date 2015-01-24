using UnityEngine;
using System.Collections;


public class Initialize : MonoBehaviour {

	//Player ref
	public GameObject playerGO;
	private Player player;

	// UI Textures
	public Texture portraitImg;
	public Texture inventoryImg;
	public Texture healthbarBackground;

	// Inventory Variables
	bool inventoryOpen = false;
	int selGridInt = 0;
	Texture[] inventoryTextures = new Texture[MyConstants.NUM_ITEM_TYPES];
	string[] inventoryLabels = new string[MyConstants.NUM_ITEM_TYPES];

	// Health/Stamina Bar Variables
	int healthbarLength = 100;
	int healthbarMaxLength = 100;
	int staminabarLength = 100;
	int staminabarMaxLength = 100;

	// Use this for initialization
	void Start () {

		player = playerGO.GetComponent<Player> ();

	
		for (int i = 0; i < MyConstants.NUM_ITEM_TYPES; i++) 
		{
			inventoryTextures[i] = inventoryImg;
			inventoryLabels [i] = ((ItemType)i).ToString () + ": " + + player.inventory.GetItemAmount((ItemType)i);

		}
	}
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < MyConstants.NUM_ITEM_TYPES; i++) 
		{
			inventoryLabels [i] = ((ItemType)i).ToString () + ": " + + player.inventory.GetItemAmount((ItemType)i);

		}

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
			GUI.SelectionGrid (new Rect (Screen.width - Screen.width / 5, Screen.height - Screen.height / 3 - Screen.width / 15, Screen.width / 5, Screen.height / 3), selGridInt, inventoryLabels, 2);
		} 
		else {
			selGridInt = -1;
		}
	}
	
}
