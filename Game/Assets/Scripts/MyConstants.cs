using UnityEngine;
using System.Collections;

public enum ItemType
{
	SHOVEL, AXE, KNIFE, FLINT, WOOD, FEATHERS, MATCHES, ROPE, CLOTH, FAIRYDUST, SHIP, WINGS
}


public class MyConstants {
	public const int NUM_ITEM_TYPES = 12;
	public const int CAMERA_HEIGHT = 400;
	public const int WATER_HEIGHT_LEVEL = 150;
	
	public const float PLAYER_HEIGHT = 5.0f;
	
	//Radii
	//Player
	public const float PLAYER_DAMAGE = 100.0f;
	public const float PLAYER_SPEED = 1.0f;
	public const int INTERACT_DISTANCE = 50;
	public const float PLAYER_ATTACK_DISTANCE = 40;
	
	//AI
	public const int AWARENESS_RADIUS = 75;
	public const int ARRIVE_RADIUS = 25;
	public const int PIRATE_DAMAGE = 5;
	public const float PIRATE_SPEED = PLAYER_SPEED + 0.2f;
	public const int FOLLOW_DISTANCE = AWARENESS_RADIUS * 4;

	//Endings
	public const int NUM_ENDINGS = 8;
	public static bool[] ENDINGS_UNLOCKED;
	public static string[] ENDINGS;
	
	
	public static void Init()
	{
		ENDINGS_UNLOCKED = new bool[NUM_ENDINGS];
		
		for (int i = 0; i < MyConstants.NUM_ENDINGS; i++) 
		{
			ENDINGS_UNLOCKED[i] = false;
		}
		
		MyConstants.ENDINGS = new string[NUM_ENDINGS]
		{
			"Patience - You waited and rescue arrived.",
			"Tunnel - You dug your way off the island.",
			"Portal - You made it past the dragon and found the portal.",
			"Prayer - You worshipped the gods and they saved you.",
			"Plunder - You stole the pirates ship",
			"Icarus - You built wings and flew off the island.",
			"Death - You left the island.",
			"Sail - You built a boat and sailed away."
		};
	}

	public static void Win(int ending)
	{
		MyConstants.ENDINGS_UNLOCKED [ending] = true;
		Debug.Log (MyConstants.ENDINGS[ending]);
		Application.LoadLevel ("GameOver");
	}
}
