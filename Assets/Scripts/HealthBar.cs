using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateHealth(int health) {
		int childCount = transform.childCount;

		for(int i = 0; i < childCount; i++) {
			Transform child = transform.GetChild (i);
			child.gameObject.SetActive (false);
		}

		for(int i = childCount; i > childCount - health ; i--) {
			Transform child = transform.GetChild (i - 1);
			child.gameObject.SetActive (true);
		}
	}
}
