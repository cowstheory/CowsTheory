using UnityEngine;
using System.Collections;

public class Bullet2 : MonoBehaviour
{
    public GameObject This;
    public float Damage = 0.2F;
    private int ownerId;
    private Rigidbody rb;
    private GameObject owner;
    private PhysicsBehaviour pb;

    private float lifeSpan, spawnTime;

    private float RecoilCoefficient = 10.0F; //higher value means that WE will fly backwards more quickly
    private float BulletSpeed = 30.0F;
    //private float Mass = 32.0F;
    private float Mass = 2.0F;

    // Feel free to add your own type of bullet. Remember to define it in BulletType.cs
    private void CreateBullet(BulletType bulletType)
    {
        float damage, recoilCoefficent, bulletSpeed, mass;
        switch (bulletType)
        {
            case BulletType.MINOR:
                damage = 0.2F;
                recoilCoefficent = 12.0F;
                bulletSpeed = 40.0F;
                mass = 2.0F;
                break;
            case BulletType.HEAVY:
                damage = 0.4F;
                recoilCoefficent = 20.0F;
                bulletSpeed = 20.0F;
                mass = 4.0F;
                break;
            case BulletType.EXPLOSIVE:
                damage = 0.1F;
                recoilCoefficent = 15.0F;
                bulletSpeed = 10.0F;
                mass = 4.0F;
                break;
            default:
                damage = 0.1F;
                recoilCoefficent = 10.0F;
                bulletSpeed = 30.0F;
                mass = 2.0F;
                break;
        }
            
        this.Damage = damage;
        this.RecoilCoefficient = recoilCoefficent;
        this.BulletSpeed = bulletSpeed;
        this.Mass = mass;
    }

    void Awake()
    {
    }

    public Bullet2 Initialize()
    {
        rb = GetComponent<Rigidbody>();
        pb = new PhysicsBehaviour(This);
        //pb.setGravityFactor(1.2F);
        pb.setGravityFactor(1.4F);
        this.lifeSpan = 3.0F;
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
    public Vector3 shoot(Vector3 direction, float angle, BulletType bulletType)
    {
        // Assign bullet properties
        CreateBullet(bulletType);

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
