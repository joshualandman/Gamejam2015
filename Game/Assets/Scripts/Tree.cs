using UnityEngine;
using System.Collections;

public class Tree : Interactable {

	Player playerSc;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Interact(GameObject obj)
	{
		Player p = obj.GetComponent<Player> ();
		if(p.inventory.ContainsItem (ItemType.AXE))
		{
			p.inventory.AddItems(ItemType.WOOD,2);
			Destroy (gameObject);
		}
	}
}
