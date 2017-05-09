using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Bomb", 0f, 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Bomb() {
		Vector3 position = transform.position;
		GameObject seamine = PoolManager.instance.GetObjectForType("Seamine", true);

		if (seamine != null) {
			seamine.transform.localPosition = position;
		}
	}
}
