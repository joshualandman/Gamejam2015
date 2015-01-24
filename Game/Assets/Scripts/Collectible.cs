using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

	ItemType type;
	int amount;

	// Use this for initialization
	void Start (ItemType t, int amt) {
		type = t;
		amount = amt;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
