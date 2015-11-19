using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
  	public GameObject powerupGO;
	public int id;
	public float gravityFactor = 0F; // then tune this value  in editor too
	
	private GameObject blackHole;
	private Rigidbody rb;
	private Bullet bullet;
	private PhysicsBehaviour pb;
        
	public Powerup(){
	}
        
	void OnTriggerEnter(Collider other){
            if (other.tag == "Player") {
                Player p = other.GetComponent<Player>();
                p.receievePowerup(this);
                Destroy(powerupGO);
            }
	}
}
