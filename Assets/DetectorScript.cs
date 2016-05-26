using UnityEngine;
using System.Collections;

public class DetectorScript : MonoBehaviour {

	GameObject parent;
	// Use this for initialization
	void Start () {
		parent = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (gameObject != null) {
			if (collider.tag == "SnakeTransition") {
				Vector2 escapeDirection = new Vector2 ((this.transform.position.x - collider.transform.position.x), (this.transform.position.y - collider.transform.position.y));
				escapeDirection.Normalize ();
				escapeDirection *= 8;
				parent.GetComponent<Rigidbody2D> ().AddForce (escapeDirection);
				parent.GetComponent<SlimeScript> ().escaping = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (gameObject != null) {
			if (collider.tag == "SnakeTransition") {
				parent.GetComponent<SlimeScript> ().escaping = false;
			}
		}
	}
}
