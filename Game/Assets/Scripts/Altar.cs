using UnityEngine;
using System.Collections;

public class Altar : Interactable {

	private Torch[] torches = new Torch[4];

	// Use this for initialization
	void Start () {
		//Create 4 torches around the altar
		float _x = transform.position.x;
		float _y = transform.position.y;
		float _z = transform.position.z;
		torches[0] = new Torch(_x, _y, _z);
		torches[1] = new Torch(_x+10, _y, _z);
		torches[2] = new Torch(_x+20, _y, _z);
		torches[3] = new Torch(_x+30, _y, _z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
