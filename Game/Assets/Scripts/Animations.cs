using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GameObject.Find ("Player").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetInteger ("AnimState", 0);
	}
}
