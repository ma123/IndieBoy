﻿using UnityEngine;
using System.Collections;

public class ScreenAdjustScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera.main.aspect = 480f / 800f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
