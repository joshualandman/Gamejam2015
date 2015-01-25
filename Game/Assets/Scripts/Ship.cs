using UnityEngine;
using System.Collections;

public class Ship : Interactable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Interact(GameObject obj)
	{
		Player p = obj.GetComponent<Player> ();
		MyConstants.Win(4);
	}
}
