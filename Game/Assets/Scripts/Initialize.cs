﻿using UnityEngine;
using System.Collections;

public class Initialize : MonoBehaviour {
	
	public Texture portraitImg;
	public Texture inventoryImg;

	public GUISkin backgroundSlider;
	public GUISkin foregroundSlider;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI() {
		// Player portrait
		GUI.DrawTexture (new Rect (10, 10, Screen.width/15, Screen.width/15), portraitImg);
		// Inventory Button
		GUI.DrawTexture (new Rect (Screen.width - Screen.width/10, Screen.height - Screen.width/10, Screen.width/10, Screen.width/10), inventoryImg);
		// Health Bar
		GUI.HorizontalSlider (new Rect (10 + Screen.width / 15 + 5, 10, Screen.width / 5, Screen.height / 20), 5, 0, 10, backgroundSlider.horizontalSlider, backgroundSlider.horizontalSliderThumb);
		GUI.HorizontalSlider (new Rect (11 + Screen.width / 15 + 5, 11, Screen.width / 5 - 2, Screen.height / 10 - 2), 5, 0, 10, foregroundSlider.horizontalSlider, foregroundSlider.horizontalSliderThumb);
		// Stamina Bar
		GUI.HorizontalSlider (new Rect (10 + Screen.width / 15 + 5, 10 + Screen.height / 20 + 5, Screen.width / 5, Screen.height / 20), 10, 0, 10);
	}
	
}