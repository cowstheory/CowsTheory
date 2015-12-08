using System;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    private float SpreadArc;
    private float[] SpreadAngles;
    private int BulletsPerShot;

    public GameObject BulletType;   // Assign what bullet type the weapon has, affects damage etc.
    private GameObject Owner;

    public Weapon2(float spreadArc, int bulletsPerShot)
	{
        this.SpreadArc = spreadArc;
        this.BulletsPerShot = bulletsPerShot;
        CalculateSpread();
	}

    public void setOwner(GameObject owner)
    {
        this.Owner = owner;
    }

    // returns directional vector opposite to shooting direction
    public Vector3 shoot(Vector3 direction, WeaponType type)
    {
        Vector3 force = new Vector3();

        for (int i = 0; i < BulletsPerShot; ++i)
        {
            Bullet2 bullet = ((GameObject)Instantiate(BulletType, this.transform.position, new Quaternion())).GetComponent<Bullet2>().Initialize();
            bullet.setOwner(this.Owner);
            bullet.setOwnerId(this.Owner.GetComponent<Player>().getId());
            force += bullet.shoot(direction, SpreadAngles[i]);
        }

        return force;
    }

    private void CalculateSpread()
    {
        // If the spread is set to 0, set the angle array to zero as well (fire in a straight line).
        if(SpreadArc == 0)
        {
            this.SpreadAngles = new float[]{ 0F};
            return;
        }
        // If the spread is >0, the angle array will be angles evenly distributing BulletsPerShot over SpreadArc angle-range.
        else { 
        float step = (SpreadArc / (BulletsPerShot - 1));
        float start = -(SpreadArc / 2.0F);
        float[] angles = new float[BulletsPerShot];

        for (int i = 0; i < BulletsPerShot; ++i)
        {
            angles[i] = (start + (i * step));
        }
            this.SpreadAngles = angles;
            return;
        }
    }
}
