using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameScript : MonoBehaviour {

	public static float snake_length = 1f;

	public static int lowest_snake_layer = 1000;

	public static bool gameOver = false;

	public static Sprite[] slimes;

	public static float speed;

	public static int speedingTime;

	public static int fireTime;

	public static List<Vector2> traceList = new List<Vector2>();


	void Awake () {
		slimes = Resources.LoadAll<Sprite> ("Slimes") as Sprite[];
	}


	// Use this for initialization
	void Start () {
		speed = 0f;
		speedingTime = 0;
		fireTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//snake_length += 0.001f;
		int rand = (int)Random.Range(0, 1000);
		if (rand == 500) {
			Vector3 pos = new Vector3 (Random.Range (-9f, 9f), Random.Range (-4f, 4f));
			GameObject speedPotionPrefab = Resources.Load<GameObject> ("SpeedPotion") as GameObject;
			Instantiate (speedPotionPrefab, pos, Quaternion.identity);
		} else if (rand == 501) {
			Vector3 pos = new Vector3 (Random.Range (-9f, 9f), Random.Range (-4f, 4f));
			GameObject firePotionPrefab = Resources.Load<GameObject> ("FirePotion") as GameObject;
			Instantiate (firePotionPrefab, pos, Quaternion.identity);
		}
	}

	void OnGUI () {
		if (gameOver) {
			GUI.Label (new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Game Over"); //Display message
		}
	}
}
