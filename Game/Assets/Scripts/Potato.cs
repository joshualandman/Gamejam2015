using UnityEngine;
using System.Collections;

public class Potato : Interactable {

	public bool isLit = false;
	public ParticleSystem flames;
	Transform potato = GameObject.Find("Torch").GetComponent<Transform>();
	Transform potato2;

	public Potato(float x, float y, float z)
	{
		potato2 = Instantiate (potato, new Vector3(x, y, z), Quaternion.identity) as Transform;
	}

	// Use this for initialization
	void Start () {
		flames.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Interact(GameObject obj)
	{
		Player p = obj.GetComponent<Player>();
		if(true || p.inventory.ContainsItem (ItemType.MATCHES))
		{
			isLit = !isLit;
			if(isLit)
			{
				flames.Play ();
			}
			else
			{
				flames.Stop();
			}
		}
		else
		{
			isLit = false;
		}

	}
}
