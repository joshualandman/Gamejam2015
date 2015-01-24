using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	//insert object to follow
	public Transform followObject;

	void Start()
	{
	}

	// Update is called once per frame
	void Update () {
		//set a position slightly behing the object
		Vector3 pos = new Vector3
			(followObject.transform.position.x,
			followObject.transform.position.y + 10f,
			 followObject.transform.position.z);

		//set self to position
		transform.position = pos;
	}
}