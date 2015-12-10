using UnityEngine;
using System.Collections;

public class PhysicsBehaviour{
	
	private float gravityFactor = 1.0F;
	private GameObject blackHole;
	private Rigidbody rb;
	
	public PhysicsBehaviour(GameObject go){
		blackHole = GameObject.Find ("BLACKHOLE");
		this.rb = go.GetComponent<Rigidbody>();
	}

	public void setGravityFactor(float gf){
		this.gravityFactor = gf;

        if (this.gravityFactor < 1.0F) {
            Debug.LogError("Trying to set gravityFactor to less than 1.0F");
        }
	}

	public void addGravityFactor(float amount){
        this.gravityFactor = Mathf.Max(1.0F, this.gravityFactor + amount);
    }

	public string getGravityFactorText(){
		return ((this.gravityFactor - 1.0F) * 100).ToString ("F0") + "%";
	}
    
	public float getGravityFactor(){
		return (this.gravityFactor);
	}

	public void updatePhysics(){
            float velocityDiff;
            if (rb.transform.position.magnitude < con.EVENT_HORIZON_RADIUS) {
                    velocityDiff = 4*(con.GRAVITY_COEFFICIENT * Mathf.Pow (gravityFactor, con.GRAVITY_EXPONENT));
            } else {
                    velocityDiff = (con.GRAVITY_COEFFICIENT * Mathf.Pow (gravityFactor, con.GRAVITY_EXPONENT));
            }
            rb.velocity += (blackHole.transform.position - rb.transform.position).normalized * velocityDiff;

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
