using UnityEngine;
using System.Collections;

public class EdgeScript : MonoBehaviour {

	public char dir;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Snake") {
			switch(dir)
			{
			case 'd':
				collider.transform.position = collider.transform.position + new Vector3 (0f, 10f, 0f);
				break;
			case 'u':
				collider.transform.position = collider.transform.position + new Vector3 (0f, -10f, 0f);
				break;
			case 'l':
				collider.transform.position = collider.transform.position + new Vector3 (19f, 0f, 0f);
				break;
			case 'r':
				collider.transform.position = collider.transform.position + new Vector3 (-19f, 0f, 0f);
				break;
			}
		}
	}
}
