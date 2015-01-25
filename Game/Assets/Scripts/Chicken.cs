using UnityEngine;
using System.Collections;

public class Chicken : MonoBehaviour {

	GameObject[] path = new GameObject[6];
	Player p;
	public float health;
	public GameObject target;
	int count = 0;
	public GameObject t0;
	public GameObject t1;
	public GameObject t2;
	public GameObject t3;
	public GameObject t4;
	public GameObject t5;

	// Use this for initialization
	void Start () {
		p = GameObject.Find("Player").GetComponent<Player>();

		health = 100.0f;

		path[0] = t0;
		path[1] = t1;
		path[2] = t2;
		path[3] = t3;
		path[4] = t4;
		path[5] = t5;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health <= 0)
		{
			p.inventory.AddItems(ItemType.FEATHERS, 100);
			p.itemName = "100 " + ItemType.FEATHERS.ToString ();
			p.pickedUpItem = true;

			Destroy (gameObject);
		}

		Vector3 seekVec = AI.Seek(gameObject.transform.position, target.transform.position, MyConstants.PIRATE_SPEED);
		Move (seekVec);
		
		//If in range for an attack
		if(AI.InRange (gameObject.transform.position, target.transform.position, MyConstants.ARRIVE_RADIUS))
		{
			count++;
			if(count >= 6)
			{
				count = 0;
			}
			target = path[count];
		}
	}

	void Move(Vector3 translationVec)
	{
		Vector3 newPos = new Vector3();
		newPos.x = transform.position.x;
		newPos.y = transform.position.y;
		newPos.z = transform.position.z;
		
		newPos += translationVec;
		
		//Height of gameObject
		float height = ((Renderer)gameObject.GetComponent ("Renderer")).bounds.size.y;
		
		//Height of terrain
		float terrainHeight = Terrain.activeTerrain.SampleHeight (newPos) + Terrain.activeTerrain.GetPosition ().y + (height / 2.0f);
		
		newPos = new Vector3 (newPos.x, terrainHeight, newPos.z);
		
		//And you are not walking into water
		if(newPos.y > MyConstants.WATER_HEIGHT_LEVEL)
		{
			gameObject.transform.position = newPos;
		}
	}
}
