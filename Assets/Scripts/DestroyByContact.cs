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
		Instantiate (asteroidExplosionTemplate, transform.position, transform.rotation);

		// also create player explosion
		if (other.tag == "Player") {
			Instantiate(playerExplosionTemplate, other.transform.position, other.transform.rotation);
		}

		Destroy(other.gameObject);
		Destroy(gameObject);
	}

}
