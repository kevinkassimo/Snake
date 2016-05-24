using UnityEngine;
using System.Collections;

public class TextureScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Snake") {
			collider.transform.position = collider.transform.position + new Vector3 (0f, 11f, 0f);
		}
	}
}
