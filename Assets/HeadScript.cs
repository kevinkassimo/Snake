using UnityEngine;
using System.Collections;

public class HeadScript : MonoBehaviour
{

	public GameObject ballPrefab;
	public GameObject firePrefab;
	private GameObject currFire;

	public bool is_firing = false;

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

		if (Input.GetKey (KeyCode.F)) {
			if(GameScript.fireTime > 0) {
				if (is_firing == false) {
					currFire = Instantiate (firePrefab, transform.position, transform.rotation) as GameObject;
					is_firing = true;
				} else {
					currFire.transform.position = transform.position;
					currFire.transform.rotation = transform.rotation;
				}
				GameScript.fireTime--;
				Debug.Log ("Firing!!!");
			} else {
				is_firing = false;
				if (currFire != null) {
					Destroy (currFire);
					currFire = null;
				}
				Debug.Log ("Out of speeding potion");
			} 
		}

		if (Input.GetKeyUp (KeyCode.F)) {
			if (is_firing == true) {
				if (currFire != null) {
					Destroy (currFire);
					currFire = null;
				}
				is_firing = false;
			}
		}
	}

	IEnumerator CreateBody ()
	{
		Vector2 prevPos = transform.position;

		while (true) {
			prevPos = transform.position;
			GameScript.traceList.Add (prevPos);
			yield return new WaitForSeconds (0.01f * GameScript.speed);
			GameObject GO = Instantiate (ballPrefab, prevPos, transform.rotation) as GameObject;
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
		} else if (collision.collider.tag == "FirePotion") {
			GameScript.fireTime += 100;
			Destroy (collision.collider.gameObject);
		}
	}
}
