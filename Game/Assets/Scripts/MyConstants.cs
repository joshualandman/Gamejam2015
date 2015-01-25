using UnityEngine;
using System.Collections;

public enum ItemType
{
	SHOVEL, AXE, KNIFE, FLINT, WOOD, FEATHERS, MATCHES, ROPE, CLOTH, FAIRYDUST, SHIP, WINGS
}


public class MyConstants {
	public const int NUM_ITEM_TYPES = 12;
	public const int CAMERA_HEIGHT = 300;
	public const int WATER_HEIGHT_LEVEL = 150;
	
	public const float PLAYER_HEIGHT = 5.0f;
	
	//Radii
	//Player
	public const float PLAYER_SPEED = 1.0f;
	public const int INTERACT_DISTANCE = 50;
	//AI
	public const int AWARENESS_RADIUS = 75;
	public const int ARRIVE_RADIUS = 25;
	public const int PIRATE_DAMAGE = 5;
	public const float PIRATE_SPEED = PLAYER_SPEED + 0.2f;
	public const int FOLLOW_DISTANCE = AWARENESS_RADIUS * 4;
	
	public static void Win(int ending)
	{
		Debug.Log (string.Format ("You win with ending {0}", ending));
	}
}
