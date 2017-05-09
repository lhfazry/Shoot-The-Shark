using UnityEngine;
using System.Collections;

public class Torpedo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D collider ) {
		Debug.Log ("OnTriggerEnter2D torpedo");
		GameObject other = collider.gameObject;

		if (other.name.Equals ("Shark")) {
			PoolManager.instance.PoolObject (gameObject);
			PoolManager.instance.PoolObject (other);
			GameManager.instance.IncreaseScrore ();
		} else if (other.name.Equals ("Seamine")) {
			PoolManager.instance.PoolObject (gameObject);
			PoolManager.instance.PoolObject (other);
		}
	}
}
