using UnityEngine;
using System.Collections;

public class DetectorScript : MonoBehaviour {

	SlimeScript slimeScript;

	GameObject parent;

	Vector2 escapeDirection;
	// Use this for initialization
	void Start () {
		slimeScript = GetComponent<SlimeScript> ();
		parent = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (gameObject != null) {
			if (collider.tag == "SnakeTransition") {
				escapeDirection = new Vector2 ((this.transform.position.x - collider.transform.position.x), (this.transform.position.y - collider.transform.position.y));
				escapeDirection.Normalize ();
				escapeDirection *= 4;
				parent.GetComponent<Rigidbody2D> ().AddForce (escapeDirection);
				parent.GetComponent<SlimeScript> ().escaping = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (gameObject != null) {
			if (collider.tag == "SnakeTransition") {
				parent.GetComponent<Rigidbody2D> ().velocity = parent.GetComponent<Rigidbody2D> ().velocity * 0.2f;
				//parent.GetComponent<Rigidbody2D> ().AddForce (-10 * escapeDirection);
				parent.GetComponent<SlimeScript> ().escaping = false;
			}
		}
	}
}
