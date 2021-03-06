﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax;
	public float zMin, zMax;

	public float clampX(float coordinate) {
		return Mathf.Clamp(coordinate, xMin, xMax);
	}

	public float clampZ(float coordinate) {
		return Mathf.Clamp(coordinate, zMin, zMax);
	}
}

public class PlayerController : MonoBehaviour {

	public float burstSpeed;
	public Boundary boundary;
	public float tiltMultiplier;

	public GameObject plasmaBoltTemplate;
	public Transform shotSpawn;

	public float boltFireRate = 0.5f;
	private float nextBoltFire = 0.0f;

	void Update() {
		if (Input.GetButton("Fire1") && Time.time > nextBoltFire) {
			nextBoltFire = Time.time + boltFireRate;
			Vector3 position = shotSpawn.position;
			Quaternion rotation = Quaternion.identity;
			Instantiate(plasmaBoltTemplate, position, rotation);
			audio.Play ();
		}
	}

	void FixedUpdate() {

		// update movement
		float moveHorizontal = Input.GetAxis("Horizontal") * burstSpeed;
		float moveVertical = Input.GetAxis("Vertical") * burstSpeed;

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement;

		// check position
		Vector3 position = new Vector3(
			boundary.clampX(rigidbody.position.x), 0.0f, boundary.clampZ(rigidbody.position.z)
		);
		rigidbody.position = position;

		// rotate along longitudinal axis
		rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tiltMultiplier);
	}

}
