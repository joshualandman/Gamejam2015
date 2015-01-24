using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Camera camera;
	public int speed = 1;
	public float height;
	bool hasMoved = false;
	public float timer = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Move();
		DontMove();
	}

	void Move()
	{
		if(Input.GetKeyDown(KeyCode.W))
		{
			transform.position += speed * transform.forward;
			hasMoved = true;
		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			transform.position += speed * transform.right;
			hasMoved = true;
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			transform.position += speed * -transform.forward;
			hasMoved = true;
		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			transform.position += speed * -transform.right;
			hasMoved = true;
		}

		camera.transform.position = new Vector3 (transform.position.x, transform.position.y + 10, transform.position.z);

		height = Terrain.activeTerrain.SampleHeight (transform.position) + Terrain.activeTerrain.GetPosition ().y;
		
		gameObject.transform.position = new Vector3 (transform.position.x, height, transform.position.z);
		//gameObject.transform.position.y = Terrain.activeTerrain.SampleHeight(transform.position);
	}

	void DontMove()
	{
		if(!hasMoved)
		{
			timer += Time.deltaTime;
		}

		if(timer >= 60.0f)
		{
			Debug.Log("YOU WIN!");
		}
	}
}
