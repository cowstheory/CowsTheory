using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float damage = 0.1F;
    public GameObject go;
    private int ownerId;
    private Rigidbody rb;
    private Game game;
    private GameObject owner;
    private PhysicsBehaviour pb;

    private float recoilCoefficient = 1.0F;
    private float bulletSpeed = 30.0F;
    private float mass = 2.0F;

    public Bullet Initialize(){
        rb = GetComponent<Rigidbody> ();
        game = FindObjectOfType<Game> ();
        pb = new PhysicsBehaviour (go);
        pb.setGravityFactor (1.2F);
        return this;
    }

    public void setOwnerId(int ownerId){
        this.ownerId = ownerId;
    }

    public int getOwnerId(){
        return ownerId;
    }

    public void setOwner(GameObject owner){
        this.owner = owner;
    }

    void FixedUpdate(){
        pb.updatePhysics();
    }

    void Update(){
        if (transform.position.magnitude > game.width) {
            Destroy(go);
        }
    }

    /**
     * 
     * Returns force backwards that can be used for e.g. player recoil
     **/
    public Vector3 shoot(Vector3 direction){
        Vector3 velocityChange = bulletSpeed * direction;
        this.rb.velocity = velocityChange;

        return -velocityChange * mass * recoilCoefficient;
    }

    public float getMass(){
        return mass;
    }

    public float getRecoilCoefficient(){
        return recoilCoefficient;
    }

    void OnTriggerEnter(Collider other){
        if (owner != other.gameObject && other.tag == "Player") {
            Player pc = other.GetComponent<Player>();
            pc.takeDamage(damage);
            Destroy(go);
        }
    }
}
