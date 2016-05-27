using UnityEngine;
using System.Collections;

public class PotionScript : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	// Use this for initialization

	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Start () {
		StartCoroutine (CreatePotion ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator CreatePotion () {
		Color sprite_color = spriteRenderer.color;
		sprite_color.a = 0f;
		spriteRenderer.color = sprite_color;

		int i = 0;
		while (i < 100) {
			sprite_color = spriteRenderer.color;
			sprite_color.a = sprite_color.a + 0.01f;
			spriteRenderer.color = sprite_color;
			i++;
			yield return new WaitForSeconds (0.005f);
		}

		StartCoroutine (WaitingToDie ());
		yield break;
	}

	IEnumerator WaitingToDie() {
		yield return new WaitForSeconds(10f);

		Color sprite_color = spriteRenderer.color;
		sprite_color.a = 1f;
		spriteRenderer.color = sprite_color;

		GetComponent<Collider2D> ().enabled = false;

		int i = 0;
		while (i < 100) {
			transform.localScale = (transform.localScale + new Vector3(0.005f, 0.005f, 0.005f));

			sprite_color = spriteRenderer.color;
			sprite_color.a = sprite_color.a - 0.01f;
			spriteRenderer.color = sprite_color;

			i++;
			yield return new WaitForSeconds (0.005f);
		}
		Destroy (gameObject);
		yield break;
	}


	void OnTriggerEnter2D(Collider2D collider) {
		//Debug.LogError ("gotoHell");
		if (collider.tag == "Wall") {
			Destroy (this.gameObject);
		}
	}
}
