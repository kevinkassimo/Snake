using UnityEngine;
using System.Collections;

public class HeadScript : MonoBehaviour
{

	public GameObject ballPrefab;
	private GameScript gameScript;

	void Awake ()
	{
		gameScript = GameObject.FindObjectOfType<GameScript> ();
	}

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (CreateBody ());
	}
	
	// Update is called once per frame
	void Update ()
	{
		//transform.LookAt (Camera.main.ScreenToWorldPoint(Input.mousePosition));
		transform.Translate (Vector3.right * 3 * Time.deltaTime);

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (new Vector3 (0f, 0f, 2f));
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (new Vector3 (0f, 0f, -2f));
		}
	}

	IEnumerator CreateBody ()
	{
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

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "SnakeBody") {
			GameScript.GameOver = true;
			Time.timeScale = 0; //Pause the game
		}
	}
}
