using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  	public GameObject playerGO, bulletGO;
	public int id;
	public float gravityFactor = 1F; // then tune this value  in editor too

	private float fireDelay = 0.4F;
	private GameObject blackHole;
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
			nextFire = Time.time + fireDelay;
			if (Input.GetKey (KeyCode.W)) {
				fireGun (Vector3.up);
			}
			else if (Input.GetKey (KeyCode.S)) {
				fireGun (Vector3.down);
			}
			if (Input.GetKey (KeyCode.A)) {
				fireGun (Vector3.left);
			}
			else if (Input.GetKey (KeyCode.D)) {
				fireGun (Vector3.right);
			}
		} else if(Time.time > nextFire){
			nextFire = Time.time + fireDelay;
			if (Input.GetKey (KeyCode.UpArrow)) {
				fireGun (Vector3.up);
			}
			else if (Input.GetKey (KeyCode.DownArrow)) {
				fireGun (Vector3.down);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				fireGun (Vector3.left);
			}
			else if (Input.GetKey (KeyCode.RightArrow)) {
				fireGun (Vector3.right);
			}
		}
    }

	void fireGun(Vector3 direction){
		bullet = ((GameObject)Instantiate(bulletGO, this.transform.position, new Quaternion())).GetComponent<Bullet>().Initialize();
		bullet.setOwner (playerGO);
		rb.AddForce(bullet.shoot (direction));
	}

	public void takeDamage(float damage){
		pb.addGravityFactor (damage);
		if(this.GetComponent<TextMesh>() != null)
			this.GetComponent<TextMesh> ().text = pb.getGravityFactorText();
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "BLACKHOLE") {
			rb.Sleep ();
			playerGO.transform.position = new Vector3 (Random.Range (5, 10), Random.Range (5, 10), 0);
			rb.WakeUp ();
			rb.velocity = Vector3.up * 5.0F;
		}
	}
}
