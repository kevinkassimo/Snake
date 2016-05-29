using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loadlevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel(string scene_name) {
		SceneManager.LoadScene (scene_name);
	}
}
