using UnityEngine;
using System.Collections;

public class Torch : Interactable {

	bool isLit = false;
	public GameObject torch;

	public Torch(float x, float y, float z)
	{
		torch = new GameObject("Torch");
		torch.transform.position = new Vector3(x, y, z);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(isLit)
		{
			//fire animation
		}
	}

	public void Interact(GameObject obj)
	{
		Player p = obj.GetComponent<Player>();
		if(p.inventory.ContainsItem(ItemType.MATCHES))
		{
			isLit = !isLit;
		}
		else
		{
			isLit = false;
		}
	}
}
