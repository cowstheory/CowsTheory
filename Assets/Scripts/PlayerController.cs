using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  	public GameObject playerGO, bulletGO;
	public int id;
	public float gravityFactor = 1F; // then tune this value  in editor too

	private float fireRate = 0.05F;
	private GameObject blackHole;
	private float force = 7F;
	private float bulletSpeed = 10F;
	private float nextFire = 0.0f;
	private Rigidbody rb;

	private Bullet bullet;

	private PhysicsBehaviour pb;

    void Start () {
		rb = playerGO.GetComponent<Rigidbody> ();
		pb = new PhysicsBehaviour (playerGO);
    }

	
	void FixedUpdate(){
		pb.updatePhysics ();
	}

    // Update is called once per frame
    void Update () {

		if (id == 1 && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (Input.GetKey (KeyCode.W)) {
				rb.AddForce (new Vector3 (0, -force, 0));
				Shoot (new Vector3(0,bulletSpeed,0));
			}
			else if (Input.GetKey (KeyCode.S)) {
				rb.AddForce (new Vector3 (0, force, 0));
				Shoot (new Vector3(0,-bulletSpeed,0));
			}
			if (Input.GetKey (KeyCode.A)) {
				rb.AddForce (new Vector3 (force, 0, 0));
				Shoot (new Vector3(-bulletSpeed,0,0));
			}
			else if (Input.GetKey (KeyCode.D)) {
				rb.AddForce (new Vector3 (-force, 0, 0));
				Shoot (new Vector3(bulletSpeed,0,0));
			}
		} else if(Time.time > nextFire){
			nextFire = Time.time + fireRate;
			if (Input.GetKey (KeyCode.UpArrow)) {
				rb.AddForce (new Vector3 (0, -force, 0));
				Shoot (new Vector3(0,bulletSpeed,0));
			}
			else if (Input.GetKey (KeyCode.DownArrow)) {
				rb.AddForce (new Vector3 (0, force, 0));
				Shoot (new Vector3(0,-bulletSpeed,0));
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				rb.AddForce (new Vector3 (force, 0, 0));
				Shoot (new Vector3(-bulletSpeed,0,0));
			}
			else if (Input.GetKey (KeyCode.RightArrow)) {
				rb.AddForce (new Vector3 (-force, 0, 0));
				Shoot (new Vector3(bulletSpeed,0,0));
			}
		}
    }

	void Shoot(Vector3 velocity){
		GameObject b = (GameObject)Instantiate(bulletGO, this.transform.position, new Quaternion());
		bullet = b.GetComponent<Bullet> ();
		bullet.setOwner (playerGO);

		b.GetComponent<Rigidbody> ().velocity = velocity;
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "BLACKHOLE") {
			rb.Sleep ();
			playerGO.transform.position = new Vector3 (Random.Range (1, 4), Random.Range (1, 4), 0);
			rb.WakeUp ();
		}
	}
}
