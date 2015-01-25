using UnityEngine;
using System.Collections;

public class Pirate : MonoBehaviour {
	
	static bool firstInit = true;
	static GameObject player;
	
	Vector3 spawnPoint;
	AI.State state;
	
	float attackSpeed;
	float attackTimer;
	
	// Use this for initialization
	void Start () {
		
		if (firstInit) 
		{
			player = GameObject.Find ("Player");
			firstInit = false;
		}
		
		
		spawnPoint = gameObject.transform.position;
		state = AI.State.WAITING;
		
		attackSpeed = 1;
		attackTimer = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) 
		{
		case AI.State.WAITING:
			Wait ();
			break;
		case AI.State.SEEKING:
			Seek ();
			break;
		case AI.State.ATTACKING:
			Attack();
			break;
		case AI.State.RETURNING:
			Retreat();
			break;
		}
	}
	
	void Wait()
	{
		Debug.Log ("Waiting");
		if (AI.InRange (gameObject.transform.position, player.transform.position, MyConstants.AWARENESS_RADIUS)) 
		{
			Debug.Log ("Switching");
			
			state = AI.State.SEEKING;
		}
	}
	
	void Seek()
	{
		Debug.Log ("Seeking");
		
		//If the object is not within range of the start point
		if (!AI.InRange (gameObject.transform.position, spawnPoint, MyConstants.FOLLOW_DISTANCE)) 
		{
			state = AI.State.RETURNING;
		} 
		else 
		{
			Vector3 seekVec = AI.Seek (gameObject.transform.position, player.transform.position, MyConstants.PIRATE_SPEED);
			Move (seekVec);
			
			//If in range for an attack
			if(AI.InRange (gameObject.transform.position, player.transform.position, MyConstants.ARRIVE_RADIUS))
			{
				state = AI.State.ATTACKING;
			}
		}
	}
	
	void Attack()
	{
		Player playerScript = player.GetComponent<Player> ();
		
		if (!AI.InRange (transform.position, player.transform.position, MyConstants.ARRIVE_RADIUS)) 
		{
			state = AI.State.SEEKING;
		} 
		else 
		{
			if (attackTimer <= 0) {
				playerScript.health -= MyConstants.PIRATE_DAMAGE;
				attackTimer = attackSpeed;
			} 
			else 
			{
				attackTimer -= Time.deltaTime;
			}
			
		}
	}
	
	void Retreat()
	{
		//If the object is within range of the start point
		if (AI.InRange (gameObject.transform.position, spawnPoint, MyConstants.ARRIVE_RADIUS)) 
		{
			state = AI.State.WAITING;
		} 
		else 
		{
			Vector3 seekVec = AI.Seek (gameObject.transform.position, spawnPoint, MyConstants.PIRATE_SPEED);
			Move (seekVec);
			
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
