using UnityEngine;
using System.Collections;

public class Rubble : Interactable {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public override void Interact(GameObject obj)
	{
		Player p = obj.GetComponent<Player> ();
		if(p.inventory.ContainsItem (ItemType.SHOVEL))
		{
			Destroy (gameObject);
		}
	}
}
