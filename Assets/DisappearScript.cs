using UnityEngine;
using System.Collections;

public class DisappearScript : MonoBehaviour {
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
		yield return new WaitForSeconds (2f * GameScript.snake_length);

		Destroy (this.gameObject);

		yield break;
	}
}
