using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject asteroidExplosionTemplate;
	public GameObject playerExplosionTemplate;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") {
			return;
		}

		// create asteroid explosion
		GameObject asteroidExplosion = Instantiate (asteroidExplosionTemplate, transform.position, transform.rotation) as GameObject;

		// also create player explosion
		if (other.tag == "Player") {
			GameObject playerExplosion = Instantiate(playerExplosionTemplate, other.transform.position, other.transform.rotation) as GameObject;
		}

		Destroy(other.gameObject);
		Destroy(gameObject);
	}

}
