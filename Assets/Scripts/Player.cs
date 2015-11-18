using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
  	public GameObject playerGO, bulletGO;
	public int id;
	public float gravityFactor = 0F; // then tune this value  in editor too
	
	private GameObject blackHole;
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

	public void fireGun(Vector3 direction){
		bullet = ((GameObject)Instantiate(bulletGO, this.transform.position, new Quaternion())).GetComponent<Bullet>().Initialize();
		bullet.setOwner (playerGO);
		bullet.setId (id);
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
			playerGO.transform.position = Random.insideUnitCircle * Random.Range (10, 20);
			rb.WakeUp ();
			rb.velocity = Vector3.up * 5.0F;
		} else if (other.tag == "Bullet") {
			Bullet b = other.GetComponent<Bullet>();
			if(b.getId() != id){
				rb.velocity += other.attachedRigidbody.velocity;
//				Debug.Log (rb.velocity.magnitude);
			}
		}
	}
}
