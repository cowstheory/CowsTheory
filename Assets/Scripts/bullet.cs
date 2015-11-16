using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject go;
	private Rigidbody rb;
	private Game game;
	private GameObject owner;
	private PhysicsBehaviour pb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		game = FindObjectOfType<Game> ();
		pb = new PhysicsBehaviour (go);
	}

	public void setOwner(GameObject owner){
		this.owner = owner;
	}

	void FixedUpdate(){
		pb.updatePhysics();
	}

	void Update(){
		if (transform.position.magnitude > 1.5*game.height) {
			Destroy(go);
		}
	}

	void OnTriggerEnter(Collider other){
//		if (other.tag == "Wall" || other.name == "BLACKHOLE") {
//			Destroy (projectile);
//		}
//		Debug.Log (other.gameObject);
//		Debug.Log (owner);
		if (owner != other.gameObject && other.tag == "Player") {
			other.attachedRigidbody.AddForce(-rb.velocity);
			Destroy(go);
		}
	}
}
