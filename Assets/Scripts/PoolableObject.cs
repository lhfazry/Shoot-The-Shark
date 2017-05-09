using UnityEngine;
using System.Collections;

public class PoolableObject : MonoBehaviour {
	public enum Direction
	{
		Up, Right, Down, Left
	}

	public Direction direction;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}

	void Update () {
		Vector3 viewportPosition = Camera.main.WorldToViewportPoint (transform.position);

		if (direction == Direction.Right && viewportPosition.x > 1.2f) {
			PoolManager.instance.PoolObject (gameObject);

			if (gameObject.name.Equals ("Shark")) {
				GameManager.instance.DecreaseHealth ();
			}
		}
		else if (direction == Direction.Up && viewportPosition.y > 1.2f) {
			PoolManager.instance.PoolObject (gameObject);
		}
		else if (direction == Direction.Down && viewportPosition.y < -1.2f) {
			PoolManager.instance.PoolObject (gameObject);
		}
		else if (direction == Direction.Left && viewportPosition.x < -1.2f) {
			PoolManager.instance.PoolObject (gameObject);
		}

		switch (direction) {
		case Direction.Down:
		case Direction.Up:
			transform.Translate (new Vector3 (0, speed * Time.deltaTime, 0));
			break;
		case Direction.Left:
		case Direction.Right:
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
			break;
		}
	}
}
