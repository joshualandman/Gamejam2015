using UnityEngine;
using System.Collections;

public class Inventory {
	const int numItemTypes = 8;
	enum ItemType
	{
		SHOVEL, AXE, WOOD, FEATHERS, MATCHES, KNIFE, FLINT, ROPE
	}


	private int[] items;

	// Use this for initialization
	public Inventory () {
		items = new int[numItemTypes];

		for (int i = 0; i < numItemTypes; i++) {
			items[i] = 0;
		}
	}

	/// <summary>
	/// Adds one item to the bag.
	/// </summary>
	/// <param name="type">Type of item to add.</param>
	void AddItem(ItemType type)
	{
		items [(int)type]++;
	}

	/// <summary>
	/// Adds the items To the bag.
	/// </summary>
	/// <param name="type">Type of item to add.</param>
	/// <param name="amount">Amount to add.</param>
	void AddItems(ItemType type, int amount)
	{
		items [(int)type] += amount;
	}

	/// <summary>
	/// Takes one item from bag.
	/// </summary>
	/// <returns><c>true</c>, if item was taken, <c>false</c> otherwise.</returns>
	/// <param name="type">Type of item to take.</param>
	bool TakeItem(ItemType type)
	{
		if (items [(int)type] > 0) 
		{
			items[(int)type]--;
			return true;
		}
		return false;
	}

	/// <summary>
	/// Takes items from the bag.
	/// </summary>
	/// <returns><c>true</c>, if items was taken, <c>false</c> otherwise.</returns>
	/// <param name="type">Type of item to take.</param>
	/// <param name="amount">Amount to take.</param>
	bool TakeItems(ItemType type, int amount)
	{
		if(items[(int)type] >= amount)
		{
			items[(int)type] -= amount;
			return true;
		}
		return false;
	}

	/// <summary>
	/// Checks if the inventory contains at least one the item
	/// </summary>
	/// <returns><c>true</c>, if item was containsed, <c>false</c> otherwise.</returns>
	/// <param name="type">Type of item to check.</param>
	bool ContainsItem(ItemType type)
	{
		return items[(int)type] > 0;
	}

	/// <summary>
	/// Gets the amount of an item in the inventory.
	/// </summary>
	/// <returns>The item amount in the inventory.</returns>
	/// <param name="type">Type of item to check.</param>
	int GetItemAmount(ItemType type)
	{
		return items[(int)type];
	}
}
