using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
	
	Inventory inventory;
	
	public Camera camera;
	public int speed = 1;
	bool hasMoved = false;
	public float timer = 0.0f;
	
	// Use this for initialization
	void Start () {
		inventory = new Inventory ();
		
		float height = ((Renderer)gameObject.GetComponent ("Renderer")).bounds.size.y;
		
		
		transform.position = new Vector3 (1250.0f, 200.0f, 800.0f);
		
		float terrainHeight = Terrain.activeTerrain.SampleHeight (transform.position) + Terrain.activeTerrain.GetPosition ().y + (height / 2.0f);
		transform.position = new Vector3 (transform.position.x, terrainHeight, transform.position.z);
		camera.transform.position = new Vector3 (transform.position.x, MyConstants.CAMERA_HEIGHT, transform.position.z);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Move();
		DontMove();
	}
	
	void Move()
	{
		Vector3 newPos = new Vector3();
		newPos.x = transform.position.x;
		newPos.y = transform.position.y;
		newPos.z = transform.position.z;
		
		
		if(Input.GetKey(KeyCode.W))
		{
			newPos += speed * transform.forward;
			hasMoved = true;
		}
		if(Input.GetKey(KeyCode.D))
		{
			newPos += speed * transform.right;
			hasMoved = true;
		}
		if(Input.GetKey(KeyCode.S))
		{
			newPos += speed * -transform.forward;
			hasMoved = true;
		}
		if(Input.GetKey(KeyCode.A))
		{
			newPos += speed * -transform.right;
			hasMoved = true;
		}
		
		//Height of gameObject
		float height = ((Renderer)gameObject.GetComponent ("Renderer")).bounds.size.y;
		
		//Height of terrain
		float terrainHeight = Terrain.activeTerrain.SampleHeight (newPos) + Terrain.activeTerrain.GetPosition ().y + (height / 2.0f);
		
		newPos = new Vector3 (newPos.x, terrainHeight, newPos.z);
		
		float heightDiff = 0;
		heightDiff = newPos.y - gameObject.transform.position.y;
		
		
		
		
		//Only move if the height difference is not bigger than you
		if (Mathf.Abs(heightDiff) < 1.0f) 
		{
			//And you are not walking into water
			if(newPos.y > MyConstants.WATER_HEIGHT_LEVEL)
			{
				gameObject.transform.position = newPos;
				camera.transform.position = new Vector3 (transform.position.x, MyConstants.CAMERA_HEIGHT, transform.position.z);
			}
			
		} 
		
	}
	
	void DontMove()
	{
		if(!hasMoved)
		{
			timer += Time.deltaTime;
		}
		
		if(timer >= 60.0f)
		{
			MyConstants.Win(0);
		}
	}
}
