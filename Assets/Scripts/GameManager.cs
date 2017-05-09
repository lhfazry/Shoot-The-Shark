using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public Submarine subMarine;
	public Text textScore;
	public HealthBar healthBar;

	private int score = 0;
	private int health = 3;

	void Awake() {
		instance = this;	
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateNewShark", 0f, 5f);
		InvokeRepeating ("CreateNewFish", 0f, 3.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			CreateNewTorpedo ();
		}
	}

	void CreateNewShark() {
		float yPos = Random.Range (1.5f, 3f);
		Vector3 position = new Vector3 (-12.07f, yPos, 0f);
		//Instantiate (shark, position, Quaternion.identity);
		GameObject shark = PoolManager.instance.GetObjectForType("Shark", true);

		if (shark != null) {
			shark.transform.localPosition = position;
		}
	}

	void CreateNewTorpedo() {
		Debug.Log ("Create new torpedo");
		Vector3 subMarinePosition = subMarine.transform.position;
		Vector3 position = new Vector3 (subMarinePosition.x, subMarinePosition.y, 2f);
		GameObject torpedo = PoolManager.instance.GetObjectForType("Torpedo", true);

		if (torpedo != null) {
			torpedo.transform.localPosition = position;
		}
		//Instantiate (torpedo, position, Quaternion.identity, null);
	}

	void CreateNewFish() {
		int type = Random.Range (1, 6);
		float yPos = Random.Range (-3f, 1f);
		float xPos = 0f;
		string name = "";

		switch (type) {
		case 1:
			name = "MediumFishBrown";
			xPos = 12f;
			break;
		case 2:
			name = "MediumFishGreen";
			xPos = 12f;
			break;
		case 3:
			name = "MediumFishPurple";
			xPos = 12f;
			break;
		case 4:
			name = "SmallFishGreen";
			xPos = -12f;
			break;
		case 5:
			name = "SmallFishRed";
			xPos = -12f;
			break;
		case 6:
			name = "SmallFishYellow";
			xPos = -12f;
			break;
		}

		GameObject fish = PoolManager.instance.GetObjectForType(name, true);

		if (fish != null) {
			Vector3 position = new Vector3 (xPos, yPos, 1f);
			fish.transform.localPosition = position;
		}
	}

	public void IncreaseScrore() {
		score += 10;
		textScore.text = "" + score;
	}

	public void DecreaseHealth() {
		health--;

		if (health > 0) {
			healthBar.UpdateHealth (health);
		} else {
			//Gameover
			SceneManager.LoadScene("GameOver");
		}

		if (health == 1) {
			subMarine.ToDestroyed ();
		}
	}

	public int GetHealth() {
		return health;
	}
}
