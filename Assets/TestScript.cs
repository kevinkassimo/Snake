using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	public GameObject ballPrefab;
	private GameScript gameScript;

	void Awake () {
		gameScript = GameObject.FindObjectOfType<GameScript> ();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (CreateBody ());
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (Camera.main.ScreenToWorldPoint(Input.mousePosition));
		transform.Translate(Vector3.forward * 3 * Time.deltaTime);
	}

	IEnumerator CreateBody() {
		Vector2 prevPos = transform.position;

		while (true) {
			prevPos = transform.position;
			yield return new WaitForSeconds (0.01f);
			GameObject GO = Instantiate (ballPrefab, prevPos, Quaternion.identity) as GameObject;
			GO.GetComponent<SpriteRenderer> ().sortingOrder = GameScript.lowest_snake_layer;
			GameScript.lowest_snake_layer++;
		}
		yield break;
	}
}
