﻿	using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float damage = 0.1F;
    public GameObject go;
    private int ownerId;
    private Rigidbody rb;
    private PhysicsBehaviour pb;

	private float lifeSpan, spawnTime;

    private float recoilCoefficient = 10.0F;
    private float bulletSpeed = 30.0F;
    private float mass = 2.0F;

    public Bullet Initialize(){
        rb = GetComponent<Rigidbody> ();
        pb = new PhysicsBehaviour (go);
        pb.setGravityFactor (1.2F);
		this.lifeSpan = 1.0F;
		this.spawnTime = Time.time;
		return this;
    }

    public void setOwnerId(int ownerId){
        this.ownerId = ownerId;
    }

    public int getOwnerId(){
        return ownerId;
    }

    void FixedUpdate(){
        pb.updatePhysics();
    }

    void Update(){
		if (Time.time > (spawnTime + lifeSpan)) {
			Destroy (go);
		}
    }

    /**
     * 
     * Returns force backwards that can be used for e.g. player recoil
     **/
    public Vector3 shoot(Vector3 direction, float angle){
		Vector3 velocityChange = Quaternion.Euler(0.0F, 0.0F, angle) * (bulletSpeed * direction);
        this.rb.velocity = velocityChange;


        return -velocityChange * mass * recoilCoefficient;
    }

    public float getMass() {
        return mass;
    }

    public float getRecoilCoefficient(){
        return recoilCoefficient;
    }

    void OnTriggerEnter(Collider other){
		if (other.gameObject.GetComponent<Player> () == null)
			return;
        if (ownerId != other.gameObject.GetComponent<Player>().getId() && other.tag == "Player") {
            Player pc = other.GetComponent<Player>();
            pc.takeDamage(damage);
			//TODO: take damage sound effect

            Destroy(go);
        }
    }
}
