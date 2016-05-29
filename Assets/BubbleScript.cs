using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BubbleScript : MonoBehaviour {
	
	public int killNum;

	// Use this for initialization
	void Start () {
		StartCoroutine (Live());
		killNum = 0;
		GameObject[] slimes = GameObject.FindGameObjectsWithTag ("Slime");
		foreach (GameObject slime in slimes) {
			if (GetComponent<Collider2D> ().bounds.Contains (slime.transform.position)) {
				Destroy (slime);
				killNum++;
			}
		}

	}

	//collider.bounds.Contains(position)

	// Update is called once per frame
	void Update () {
	
	}

	/*void OnTriggerStay2D(Collider2D collider) {
		if (collider.tag == "Slime") {
			Debug.LogError ("deleting");
			Destroy (collider.gameObject);
			killNum++;
		}
	}*/

	IEnumerator Live() {
		yield return new WaitForSeconds (0.01f);

		if (killNum > 0) {
			GameScript.snake_length += 0.1f * killNum;
			GameScript.traceList.Clear ();
			GameObject[] killed = GameObject.FindGameObjectsWithTag ("Trace");
			foreach (GameObject item in killed) {
				Destroy (item);
			}
		}
		Destroy (gameObject);
		yield break;
	}
}
