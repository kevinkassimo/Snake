using UnityEngine;
using System.Collections;

public class TraceScript : MonoBehaviour {

	private SpriteRenderer spriteRenderer;

	private bool first_color_pass = false;
	private bool has_started_change_color = false;
	private float color_timer = 0f;
	private bool second_color_pass = false;

	private float startTime;
	private float color_speed;
	private float trans_covered;
	private float frac_journey;
	private float journey_length = 1f;


	public GameObject wallPrefab;

	void Awake () {
	}

	// Use this for initialization
	void Start () {
		
		//journey_length = GetColorDiffMagnitude (color, color_1);
		StartCoroutine (SolidateCoroutine ());
	}
	
	// Update is called once per frame
	void Update () {
		if (first_color_pass) {
			Instantiate (wallPrefab, transform.position, Quaternion.identity);
			Destroy (gameObject);
			/*
			if (has_started_change_color == false) {
				has_started_change_color = true;
			}
			color_timer += Time.deltaTime;

			trans_covered = (Time.time - startTime) * color_speed;
			frac_journey = trans_covered / journey_length;

			Debug.LogError ("ERROR!!!!!!!");
			spriteRenderer.color = HSBColor.ToColor(HSBColor.Lerp (color, color_1, frac_journey));
			if (color_timer == 1f) {
				this.tag = "Wall";
				first_color_pass = false;
			}*/
		}
	}

	IEnumerator SolidateCoroutine() {
		int i = 0;
		while (i < 100) {
			yield return new WaitForSeconds (0.05f);
			i++;
		}
		first_color_pass = true;
		yield break;
	}

}
