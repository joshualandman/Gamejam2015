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

	public const int INTERACT_DISTANCE = 50;
	
	public static void Win(int ending)
	{
		Debug.Log (string.Format ("You win with ending {0}", ending));
	}
}
