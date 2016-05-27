using UnityEngine;
using System.Collections;

public class SlimeScript : MonoBehaviour {
	public int color;
	private int time;
	private int scale;
	public bool escaping;

	// Use this for initialization
	void Start () {
		if (this.gameObject != null) {
			GetComponent<Rigidbody2D> ().freezeRotation = true;
		}
		time = 0;
		scale = 20;
		escaping = false;
		this.transform.position = new Vector3 (Random.Range(-9f, 9f), Random.Range(-4f, 4f), 0f);
	}

	// Update is called once per frame
	void Update () {
		this.GetComponent<SpriteRenderer>().sprite = GameScript.slimes[2*color + ((time / scale) % 2)];
		time++;
		if (time % scale == 0 && ! escaping) {
			Vector2 moveBy = new Vector2 (Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
			moveBy *= 8;
			this.GetComponent<Rigidbody2D> ().AddForce (moveBy);
		}
	}

}
