using UnityEngine;
using System.Collections;

public class BodyScript : MonoBehaviour {
	
	public bool should_disappear_under_time = true;

	// Use this for initialization
	void Start () {
		if (should_disappear_under_time) {
			StartCoroutine (DisappearCoroutine ());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator DisappearCoroutine() {
		float time = 0.2f * GameScript.snake_length;

		yield return new WaitForSeconds (time);

		this.tag = "SnakeBody";
		this.gameObject.layer = 10;

		yield return new WaitForSeconds (5*time);

		Destroy (this.gameObject);

		yield break;
	}
}
