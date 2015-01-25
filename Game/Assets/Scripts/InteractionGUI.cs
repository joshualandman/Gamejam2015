using UnityEngine;
using System.Collections;

public class InteractionGUI : MonoBehaviour {

	public GameObject player;
	private Inventory inventory;
	public Texture backgroundImg;
	int backgroundW;
	int backgroundH;
	int backgroundX;
	int backgroundY;
	bool display = false;

	// Use this for initialization
	void Start () {
		inventory = player.GetComponent<Player> ().inventory;

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
		if (GUI.Button (new Rect (backgroundX + backgroundW - backgroundW / 5, backgroundY + backgroundH / 3 - backgroundH / 20, backgroundW / 8, backgroundH / 10), "Build!")) {
			
			if (inventory.GetItemAmount (ItemType.WOOD) >= 10 && inventory.GetItemAmount (ItemType.ROPE) >= 5 && inventory.ContainsItem (ItemType.CLOTH)) {
				inventory.TakeItems (ItemType.WOOD, 10);
				inventory.TakeItems (ItemType.ROPE, 5);
				inventory.TakeItem (ItemType.CLOTH);
				
				
				inventory.AddItem (ItemType.SHIP);
			}
		}


		// Wings Build Button
		if(GUI.Button (new Rect (backgroundX + backgroundW - backgroundW / 5, backgroundY + (backgroundH / 3) * 2 - backgroundH / 20, backgroundW / 8, backgroundH / 10), "Build!")) {
			if (inventory.GetItemAmount (ItemType.WOOD) >= 5 && inventory.GetItemAmount (ItemType.FEATHERS) >= 15) {
				inventory.TakeItems (ItemType.WOOD, 5);
				inventory.TakeItems (ItemType.FEATHERS, 15);
				
				
				inventory.AddItem (ItemType.WINGS);
			}
		}
	}

	void OnGUI() {
		if (display) {
			DisplayGUI ();
		}
	}
}
