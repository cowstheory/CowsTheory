using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public GameObject projectile;
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Wall" || other.name == "BLACKHOLE") {
			Destroy (projectile);
		}
		if (other.tag == "Player") {
			other.attachedRigidbody.AddForce(-rb.velocity);
			Destroy(projectile);
		}
	}
}
