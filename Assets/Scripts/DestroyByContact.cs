using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject asteroidExplosionTemplate;
	public GameObject playerExplosionTemplate;
	public int scoreDelta;
	private GameController gameController;

	void Start() {
		GameObject find = GameObject.FindWithTag ("GameController");
		if (find != null) {
			gameController = find.GetComponent <GameController>();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script.");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") {
			return;
		}

		// create asteroid explosion
		GameObject asteroidExplosion = Instantiate (asteroidExplosionTemplate, transform.position, transform.rotation) as GameObject;

		// also create player explosion
		if (other.tag == "Player") {
			GameObject playerExplosion = Instantiate(playerExplosionTemplate, other.transform.position, other.transform.rotation) as GameObject;
			gameController.GameOver();
		}

		gameController.IncrScore (scoreDelta);

		Destroy(other.gameObject);
		Destroy(gameObject);
	}

}
