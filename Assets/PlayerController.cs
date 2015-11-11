using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  	public GameObject player, bullet;
	public int id;
	public float gravityFactor = 1F; // then tune this value  in editor too

	private float fireRate = 0.05F;
	private GameObject blackHole;
	private float force = 7F;
	private float bulletSpeed = 10F;
	private float nextFire = 0.0f;
	private Rigidbody rb;
    void Start () {
		blackHole = GameObject.Find ("BLACKHOLE");
		rb = player.GetComponent<Rigidbody> ();
    }

	
	void FixedUpdate(){
		rb.AddForce((blackHole.transform.position - transform.position).normalized * rb.mass * gravityFactor / (blackHole.transform.position - transform.position).sqrMagnitude);
	}

    // Update is called once per frame
    void Update () {

		if (id == 1 && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (Input.GetKey (KeyCode.W)) {
				rb.AddForce (new Vector3 (0, -force, 0));
				Shoot (new Vector3(0,0.5F,0), new Vector3(0,bulletSpeed,0));
			}
			else if (Input.GetKey (KeyCode.S)) {
				rb.AddForce (new Vector3 (0, force, 0));
				Shoot (new Vector3(0,-0.5F,0), new Vector3(0,-bulletSpeed,0));
			}
			if (Input.GetKey (KeyCode.A)) {
				rb.AddForce (new Vector3 (force, 0, 0));
				Shoot (new Vector3(-0.5F,0,0), new Vector3(-bulletSpeed,0,0));
			}
			else if (Input.GetKey (KeyCode.D)) {
				rb.AddForce (new Vector3 (-force, 0, 0));
				Shoot (new Vector3(0.5F,0,0), new Vector3(bulletSpeed,0,0));
			}
		} else if(Time.time > nextFire){
			nextFire = Time.time + fireRate;
			if (Input.GetKey (KeyCode.UpArrow)) {
				rb.AddForce (new Vector3 (0, -force, 0));
				Shoot (new Vector3(0,0.5F,0), new Vector3(0,bulletSpeed,0));
			}
			else if (Input.GetKey (KeyCode.DownArrow)) {
				rb.AddForce (new Vector3 (0, force, 0));
				Shoot (new Vector3(0,-0.5F,0), new Vector3(0,-bulletSpeed,0));
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				rb.AddForce (new Vector3 (force, 0, 0));
				Shoot (new Vector3(-0.5F,0,0), new Vector3(-bulletSpeed,0,0));
			}
			else if (Input.GetKey (KeyCode.RightArrow)) {
				rb.AddForce (new Vector3 (-force, 0, 0));
				Shoot (new Vector3(0.5F,0,0), new Vector3(bulletSpeed,0,0));
			}
		}
    }

	void Shoot(Vector3 offset, Vector3 velocity){
		GameObject b = (GameObject)Instantiate(bullet, this.transform.position + offset, new Quaternion());
		b.GetComponent<Rigidbody> ().velocity = velocity;


	}

	void OnTriggerEnter(Collider other){
		if (other.name == "BLACKHOLE") {
			rb.Sleep ();
			player.transform.position = new Vector3 (Random.Range (1, 4), Random.Range (1, 4), 0);
			rb.WakeUp ();
		}
	}
}
