using UnityEngine;
using System.Collections;

public class BodyScript : MonoBehaviour {
	public static int count = 0;
	public GameObject tracePrefab;

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
		yield return new WaitForSeconds (0.1f * GameScript.snake_length);

		this.tag = "SnakeBody";

		yield return new WaitForSeconds (1f * GameScript.snake_length);


		if (count == 10) {
			//Instantiate (tracePrefab, this.transform.position, Quaternion.identity);
			Instantiate (tracePrefab, this.transform.position, transform.rotation);
			count = 0;
		}

		count++;

		Destroy (this.gameObject);

		yield break;
	}
}
