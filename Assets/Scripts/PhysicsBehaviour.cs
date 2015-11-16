using UnityEngine;
using System.Collections;

public class PhysicsBehaviour{
	
	private float gravityFactor = 1.0F;
//	private GameObject go;
	private GameObject blackHole;
	private Rigidbody rb;

	public PhysicsBehaviour(GameObject go){
		blackHole = GameObject.Find ("BLACKHOLE");
//		this.go = go;
		this.rb = go.GetComponent<Rigidbody>();
	}

	public void updatePhysics(){

		rb.velocity += (blackHole.transform.position - rb.transform.position).normalized * 
			(con.GRAVITY_COEFFICIENT * Mathf.Pow (gravityFactor, con.GRAVITY_EXPONENT));

		//this.f += game.gravity * this.gravityFactor * this.m
		//TODO: fix physics
		//        Vector3 middleOfScreen = new Vector3(game.screenw/2.0, game.screenh/2.0);
		//        float pullStrength = con.BLACK_HOLE_GRAVITY_STRENGTH * this.gravityFactor**2.0;
		//        Vector3 f = (middleOfScreen - this.pos) * pullStrength;
		//
		//        if (game.vectorToMiddle(this.pos).len() < con.EVENT_HORIZON_RADIUS) {
		//            this.f += f;
		//        } else {
		//            this.f += f*0.25;
		//        }
		//
		//        //this.v += f * 1e-4 * (this.gravityFactor)**2
		//
		//        this.v += Vector3();
		//
		//        this.a = this.f / this.m;
		//        this.f = Vector3();
		//        this.v += this.a * game.dt;
		//        this.pos += this.v * game.dt;
	}
}
