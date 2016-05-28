using UnityEngine;
using System.Collections;

public class HeadScript : MonoBehaviour
{

	public GameObject ballPrefab;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (CreateBody ());
	}
	
	// Update is called once per frame
	void Update ()
	{
		//transform.LookAt (Camera.main.ScreenToWorldPoint(Input.mousePosition));
		transform.Translate (Vector3.right * 3 * Time.deltaTime * GameScript.speed);

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (new Vector3 (0f, 0f, 2f));
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (new Vector3 (0f, 0f, -2f));
		}

		if (Input.GetKey (KeyCode.Space)) {
			if(GameScript.speedingTime > 0) {
				GameScript.speed = 1.5f;
				GameScript.speedingTime--;
				Debug.Log ("Speeding!!!");
			} else {
				GameScript.speed = 1f;
				Debug.Log ("Out of speeding potion");
			}
		} else {
			GameScript.speed = 1f;
		}
	}

	IEnumerator CreateBody ()
	{
		Vector2 prevPos = transform.position;

		while (true) {
			prevPos = transform.position;
			yield return new WaitForSeconds (0.01f * GameScript.speed);
			GameObject GO = Instantiate (ballPrefab, prevPos, Quaternion.identity) as GameObject;
			GO.GetComponent<SpriteRenderer> ().sortingOrder = GameScript.lowest_snake_layer;
			GameScript.lowest_snake_layer++;
		}
		yield break;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "SnakeBody") {
			GameScript.gameOver = true;
			Time.timeScale = 0; //Pause the game
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log ("Collision");
		if (collision.collider.tag == "SnakeBody") {
			GameScript.gameOver = true;
			Time.timeScale = 0; //Pause the game
		} else if (collision.collider.tag == "SpeedPotion") {
			GameScript.speedingTime += 100;
			Destroy (collision.collider.gameObject);
		}
	}
}
