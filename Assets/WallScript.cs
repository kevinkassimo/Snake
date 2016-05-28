using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {
	private SpriteRenderer spriteRenderer;

	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (StartAnim ());
		StartCoroutine (Shaking ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Snake") {
			
		}
	}*/

	IEnumerator StartAnim() {
		transform.localScale = new Vector3(3f, 3f, 3f);
		Color sprite_color = spriteRenderer.color;
		sprite_color.a = 0f;
		spriteRenderer.color = sprite_color;

		int i = 0;
		while (i < 100) {
			transform.localScale = (transform.localScale - new Vector3(0.02f, 0.02f, 0.02f));

			sprite_color = spriteRenderer.color;
			sprite_color.a = sprite_color.a + 0.01f;
			spriteRenderer.color = sprite_color;

			i++;
			yield return new WaitForSeconds (0.005f);
		}
		yield break;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == "SnakeTransition") {
			GameScript.gameOver = true;
		}
	}
		
	IEnumerator Shaking() {
		while (true) {
			yield return new WaitForSeconds (3f);
			iTween.ShakePosition (gameObject, new Vector3 (0.1f, 0.1f, 0.1f), 1f);
			yield return new WaitForSeconds (1f);
		}
	}
}
