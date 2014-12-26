using UnityEngine;
using System.Collections;

public class SpriteBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}

}
