using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	public static float snake_length = 1f;

	public static int lowest_snake_layer = 1000;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		snake_length += 0.001f;
	}
}
