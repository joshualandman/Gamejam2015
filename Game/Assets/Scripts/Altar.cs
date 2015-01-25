using UnityEngine;
using System.Collections;

public class Altar : Interactable {

	private Potato[] torches = new Potato[4];

	// Use this for initialization
	void Start () {
		//Create 4 torches around the altar
		float _x = transform.position.x;
		float _y = transform.position.y;
		float _z = transform.position.z;
		torches[0] = new Potato(_x+37.5f, _y, _z+37.5f);
		torches[1] = new Potato(_x+37.5f, _y, _z-37.5f);
		torches[2] = new Potato(_x-37.5f, _y, _z+37.5f);
		torches[3] = new Potato(_x-37.5f, _y, _z-37.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
