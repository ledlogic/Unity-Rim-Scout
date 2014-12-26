using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speedMin, speedMax;

	// Use this for initialization
	void Start () {
		float speed = -(Random.Range (speedMin, speedMax));
		Vector3 velocity = transform.forward * speed;
		rigidbody.velocity = velocity;

		// enforce upright and planar space combat
		rigidbody.position = new Vector3(rigidbody.position.x, 0, rigidbody.position.z);
	}
}
