using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnButtonClick(string action) {
		switch(action) {
		case "Replay":
			SceneManager.LoadScene ("Game");
			break;
		case "Menu":
			SceneManager.LoadScene ("Menu");
			break;
		}
	}
}
