﻿using UnityEngine;
using System.Collections;

public class BurnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Wall" || collider.tag == "Slime") {
			Destroy (collider.gameObject);
		}
	}
}
