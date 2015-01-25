using UnityEngine;
using System.Collections;

public class FireBad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<Player>().health -= 10;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<Player>().health -= 3;
		}
	}
}
