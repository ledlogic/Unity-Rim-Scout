using UnityEngine;
using System.Collections;

public class DestroyByExit : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}

}
