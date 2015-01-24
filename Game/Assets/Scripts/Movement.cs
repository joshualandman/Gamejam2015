using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	float speed = .1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.W))
		{
			transform.position += speed * transform.forward;
		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			transform.position += speed * transform.right;
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			transform.position += speed * -transform.forward;
		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			transform.position += speed * -transform.right;
		}
	}
}
