using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
	
	public Inventory inventory;
	
	public Camera camera;
	bool hasMoved = false;
	bool moving = false;
	public float timer = 0.0f;
	public float health = 100;
	public float maxHealth = 100;
	
	// Use this for initialization
	void Start () {
		inventory = new Inventory ();
		
		float height = ((Renderer)gameObject.GetComponent ("Renderer")).bounds.size.y;
		
		
		
		float terrainHeight = Terrain.activeTerrain.SampleHeight (transform.position) + Terrain.activeTerrain.GetPosition ().y + (height / 2.0f);
		transform.position = new Vector3 (transform.position.x, terrainHeight, transform.position.z);
		camera.transform.position = new Vector3 (transform.position.x, MyConstants.CAMERA_HEIGHT, transform.position.z);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Move();
		DontMove();
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			Interact ();
		}
	}
	
	void Move()
	{
		Vector3 newPos = new Vector3();
		newPos.x = transform.position.x;
		newPos.y = transform.position.y;
		newPos.z = transform.position.z;
		
		moving = false;

		if(Input.GetKey(KeyCode.W))
		{
			newPos += MyConstants.PLAYER_SPEED * transform.up;
			hasMoved = true;

			moving = true;
		}
		if(Input.GetKey(KeyCode.D))
		{
			newPos += MyConstants.PLAYER_SPEED * transform.right;
			hasMoved = true;

			moving = true;

		}
		if(Input.GetKey(KeyCode.S))
		{
			newPos += MyConstants.PLAYER_SPEED * -transform.up;
			hasMoved = true;

			moving = true;

		}
		if(Input.GetKey(KeyCode.A))
		{
			newPos += MyConstants.PLAYER_SPEED * -transform.right;
			hasMoved = true;

			moving = true;
		}

		if (moving) {
			GetComponent<Animator> ().SetInteger ("AnimState", 1);
		} 
		else {
			GetComponent<Animator> ().SetInteger ("AnimState", 0);
		}
		
		//Height of gameObject
		float height = ((Renderer)gameObject.GetComponent ("Renderer")).bounds.size.y;
		
		//Height of terrain
		float terrainHeight = Terrain.activeTerrain.SampleHeight (newPos) + Terrain.activeTerrain.GetPosition ().y + (height / 2.0f);
		
		newPos = new Vector3 (newPos.x, terrainHeight, newPos.z);
		
		float heightDiff = 0;
		heightDiff = newPos.y - gameObject.transform.position.y;
		
		
		//And you are not walking into water
		if(newPos.y > MyConstants.WATER_HEIGHT_LEVEL)
		{
			gameObject.transform.position = newPos;
			camera.transform.position = new Vector3 (transform.position.x, MyConstants.CAMERA_HEIGHT, transform.position.z);
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Tunnel") 
		{
			Debug.Log ("Exit reached");
			MyConstants.Win (1);
		} 
		else if (collision.gameObject.tag == "TunnelRubble") 
		{
			Debug.Log ("Hit rubble");
			if (inventory.ContainsItem (ItemType.SHOVEL)) 
			{
				Debug.Log ("Destroyed");
				Destroy (collision.gameObject);
			}
		} 
		else if (collision.gameObject.tag == "Collectible") 
		{
			Debug.Log ("Picked up shovel");
			Collectible item = collision.gameObject.GetComponent<Collectible> ();
			inventory.AddItems (item.type, item.amount);
			Destroy (collision.gameObject);
		} 
		else if (collision.gameObject.tag == "Portal")
		{
			MyConstants.Win (2);
		}
	}
	
	void DontMove()
	{
		if(!hasMoved)
		{
			timer += Time.deltaTime;
		}
		else
		{
			timer = 0.0f;
		}

		if(timer >= 60.0f)
		{
			MyConstants.Win(0);
			timer = 0.0f;
		}
	}
	
	public void Interact()
	{
		GameObject[] interactables = GameObject.FindGameObjectsWithTag ("Interactable");
		
		foreach (GameObject obj in interactables) 
		{
			Vector3 dist = gameObject.transform.position - obj.transform.position;
			if(dist.magnitude < MyConstants.INTERACT_DISTANCE)
			{
				Debug.Log ("Interracting");
				
				Interactable i = obj.GetComponent<Interactable>();
				Debug.Log (i);
				i.Interact (gameObject);
			}
		}
	}
}
