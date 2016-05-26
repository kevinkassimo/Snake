using UnityEngine;
using System.Collections;

public class BodyScript : MonoBehaviour {
	private GameScript gameScript;
	
	public bool should_disappear_under_time = true;

	void Awake () {
		gameScript = GameObject.FindObjectOfType<GameScript> ();
	}

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
		yield return new WaitForSeconds (0.3f * GameScript.snake_length);

		this.tag = "SnakeBody";
		this.gameObject.layer = 10;

		yield return new WaitForSeconds (1f * GameScript.snake_length);

		Destroy (this.gameObject);

		yield break;
	}
}
