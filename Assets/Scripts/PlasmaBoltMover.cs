using UnityEngine;
using System.Collections;

public class PlasmaBoltMover : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		Vector3 velocity = transform.forward * speed;
		rigidbody.velocity = velocity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
