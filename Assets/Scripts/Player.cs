﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject playerGO, bulletGO;
    public int id;
    public float gravityFactor = 0F; // then tune this value  in editor too
    
    private GameObject blackHole;
    private Rigidbody rb;
    private Bullet bullet;
    private PhysicsBehaviour pb;
    
    public GameObject[] gunBulletTypes;
    
    private float[] nextFire;

    void Start () {
<<<<<<< HEAD
        rb = playerGO.GetComponent<Rigidbody> ();
        pb = new PhysicsBehaviour (playerGO);
        
        gunBulletTypes = new GameObject[2];
        
        gunBulletTypes.Add(bulletGO);
        gunBulletTypes.Add(bulletGO);
        
        nextFire = new float[2];
        nextFire[0] = Time.time;
        nextFire[1] = Time.time;
    }
    
    void FixedUpdate(){
        pb.updatePhysics ();
    }
    
    public bool fireGun(Vector3 direction, int whichGun){ //returns true if we could fire the gun, else false
        if (whichGun >= gunBulletTypes.Length) {
            Debug.Log("Out of index when firing gun in Player.fireGun");
            return false;
        }
        
        bullet = ((GameObject)Instantiate(gunBulletTypes[whichGun], this.transform.position,
                    new Quaternion())).GetComponent<Bullet>().Initialize();
        
        //bullet = ((GameObject)Instantiate(bulletGO, this.transform.position, new Quaternion())).GetComponent<Bullet>().Initialize();
        bullet.setOwner(playerGO);
        bullet.setOwnerId(id);
        rb.AddForce(bullet.shoot(direction));
        
        return true;
=======
		rb = playerGO.GetComponent<Rigidbody> ();
		this.rb.mass = 5.0F;
		pb = new PhysicsBehaviour (playerGO);
>>>>>>> ef71efde0d10310c902e57b7fed77eab55d6f705
    }

    public void takeDamage(float damage){
            pb.addGravityFactor (damage);
            if(this.GetComponent<TextMesh>() != null)
                    this.GetComponent<TextMesh> ().text = pb.getGravityFactorText();
    }

<<<<<<< HEAD
    void OnTriggerEnter(Collider other){
            if (other.name == "BLACKHOLE") {
                rb.Sleep ();
                playerGO.transform.position = Random.insideUnitCircle * Random.Range (10, 20);
                rb.WakeUp ();
                rb.velocity = Vector3.up * 5.0F;
            } else if (other.tag == "Bullet") {
                Bullet b = other.GetComponent<Bullet>();
                if(b.getOwnerId() != this.id){
                        rb.velocity += other.attachedRigidbody.velocity;
                        Debug.Log (rb.velocity.magnitude);
                }
            }
    }
    
    void givePowerup(Powerup pu) {
        switch (pu.type) {
            case "shotspeedup":
                break;
            case "health":
                break;
            case default:
                Debug.Log(String.Format("%s is not a valid powerup type!", type));
                return;
        }
    }
=======
	void OnTriggerEnter(Collider other){
		if (other.name == "BLACKHOLE") {
			rb.Sleep ();
			playerGO.transform.position = Random.insideUnitCircle * Random.Range (10, 20);
			rb.WakeUp ();
			rb.velocity = Vector3.up * 5.0F;
		} else if (other.tag == "Bullet") {
			Bullet b = other.GetComponent<Bullet>();
			if(b.getId() != id){
				//m1v1 = m2v2 => v1 = m2v2/m1 = (m2/m1)v2
				rb.velocity += con.BULLET_COLLISION_MULTIPLIER *
					(other.attachedRigidbody.mass / this.rb.mass) * other.attachedRigidbody.velocity;
			}
		}
	}
>>>>>>> ef71efde0d10310c902e57b7fed77eab55d6f705
}
