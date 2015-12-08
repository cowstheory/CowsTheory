using UnityEngine;
using System.Collections;

public class Bullet2 : MonoBehaviour
{
    public GameObject This;
    public float Damage = 0.1F;
    private int ownerId;
    private Rigidbody rb;
    private GameObject owner;
    private PhysicsBehaviour pb;

    private float lifeSpan, spawnTime;

    private float RecoilCoefficient = 10.0F;
    private float BulletSpeed = 30.0F;
    private float Mass = 2.0F;

    public Bullet2(float damage, float recoilCoefficent, float bulletSpeed, float mass)
    {
        this.Damage = damage;
        this.RecoilCoefficient = recoilCoefficent;
        this.BulletSpeed = bulletSpeed;
        this.Mass = mass;
    }

    public Bullet2 Initialize()
    {
        rb = GetComponent<Rigidbody>();
        pb = new PhysicsBehaviour(This);
        pb.setGravityFactor(1.2F);
        this.lifeSpan = 1.0F;
        this.spawnTime = Time.time;
        return this;
    }

    public void setOwnerId(int ownerId)
    {
        this.ownerId = ownerId;
    }

    public int getOwnerId()
    {
        return ownerId;
    }

    public void setOwner(GameObject owner)
    {
        this.owner = owner;
    }

    void FixedUpdate()
    {
        pb.updatePhysics();
    }

    void Update()
    {
        if (Time.time > (spawnTime + lifeSpan))
        {
            Destroy(This);
        }
    }

    /**
     * 
     * Returns force backwards that can be used for e.g. player recoil
     **/
    public Vector3 shoot(Vector3 direction, float angle)
    {
        Vector3 velocityChange = Quaternion.Euler(0.0F, 0.0F, angle) * (BulletSpeed * direction);
        this.rb.velocity = velocityChange;


        return -velocityChange * Mass * RecoilCoefficient;
    }

    public float getMass()
    {
        return Mass;
    }

    public float getRecoilCoefficient()
    {
        return RecoilCoefficient;
    }

    void OnTriggerEnter(Collider other)
    {
        if (owner != other.gameObject && other.tag == "Player")
        {
            Player pc = other.GetComponent<Player>();
            pc.takeDamage(Damage);
            Destroy(This);
        }
    }
}
