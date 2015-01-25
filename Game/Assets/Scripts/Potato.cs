﻿using UnityEngine;
using System.Collections;

public class Potato : Interactable {

	bool isLit = false;
	Transform potato = GameObject.Find("Torch").GetComponent<Transform>();
	Transform potato2;

	public Potato(float x, float y, float z)
	{
		potato2 = Instantiate (potato, new Vector3(x, y, z), Quaternion.identity) as Transform;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Interact(GameObject obj)
	{
		Player p = obj.GetComponent<Player>();
		if(p.inventory.ContainsItem (ItemType.MATCHES))
		{
			isLit = !isLit;
		}
		else
		{
			isLit = false;
		}
	}
}
