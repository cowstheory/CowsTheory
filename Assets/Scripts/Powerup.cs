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

    private PowerupType Type;
    private float lifeSpan, spawnTime;
    //private float Mass;

    public Powerup(){
	}

    public Powerup Initialize()
    {
        rb = GetComponent<Rigidbody>();
        pb = new PhysicsBehaviour(powerupGO);
        pb.setGravityFactor(1.2F);
        this.lifeSpan = 10.0F;
        this.spawnTime = Time.time;
        return this;
    }

    public void spawn(PowerupType powerupType) {
        CreatePowerup(powerupType);

        //Vector3 velocityChange = Quaternion.Euler(0.0F, 0.0F, angle) * (BulletSpeed * direction);
        this.rb.velocity = new Vector3(0.0F, 1.0F, 0.0F);
    }

    private void CreatePowerup(PowerupType powerupType)
    {
        Type = powerupType;
        /* float mass;
        switch (powerupType)
        {
           
            case PowerupType.HEALTHPACK:
                mass = 2.0F;
                break;
            case PowerupType.SHOTSPEED:
                mass = 4.0F;
                break;
            default:
                Debug.LogWarning("This isn't right");
                mass = 2.0F;
                break;
        } */

        //this.Mass = mass;
    }

    void OnTriggerEnter(Collider other){
            if (other.tag == "Player") {
                Player p = other.GetComponent<Player>();

                if (Type == PowerupType.HEALTHPACK) {
                    p.takeDamage(con.POWERUP_HEALTHPACK_DAMAGE);
                }

            p.receievePowerup(Type);
                Destroy(powerupGO);
            }
	}

    void Update()
    {
        if (Time.time > (spawnTime + lifeSpan))
        {
            Destroy(powerupGO);
        }
    }

    void FixedUpdate()
    {
        pb.updatePhysics();
    }
}
