using UnityEngine;
using System.Collections;

public class Submarine : MonoBehaviour {
	public float speed;
	public Sprite destroyedSubmarine;

	private SpriteRenderer spriteRendered;

	// Use this for initialization
	void Start () {
		spriteRendered = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.localPosition;

		if (Mathf.Abs (currentPosition.x) >= 5) {
			//speed = -speed;
			transform.Rotate (new Vector3(0, 180, 0));
		}

		transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
	}

	void OnTriggerEnter2D(Collider2D collider ) {
		Debug.Log ("OnTriggerEnter2D submarine");
		GameObject seamine = collider.gameObject;

		if (seamine.name.Equals("Seamine")) {
			PoolManager.instance.PoolObject (seamine);
			GameManager.instance.DecreaseHealth ();
		}
	}

	public void ToDestroyed() {
		spriteRendered.sprite = destroyedSubmarine;
	}
}
