using System;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    private float SpreadArc;
    private float[] SpreadAngles;
    private int BulletsPerShot;
    private float FireDelay;
    private BulletType LoadedBulletType;    // What type of bullet it loaded

    public GameObject[] BulletTypes;    // All the types of bullets possible
    private GameObject Owner;

    private void CreateWeapon(WeaponType weaponType)
	{
        float spreadArc, fireDelay;
        int bulletsPerShot;
        BulletType loadedBulletType;

        switch (weaponType)
        {
            case WeaponType.MACHINEGUN:
                spreadArc = 0F;
                fireDelay = 0.05F;
                bulletsPerShot = 1;
                loadedBulletType = BulletType.HEAVY;
                break;
			case WeaponType.SHOTGUN:
				spreadArc = 25F;
				fireDelay = 1.0F;
				bulletsPerShot = 7;
				loadedBulletType = BulletType.MINOR;
				break;
            default:
                spreadArc = 0F;
                fireDelay = 0.2F;
                bulletsPerShot = 1;
                loadedBulletType = BulletType.MINOR;
                break;
        }
        this.SpreadArc = spreadArc;
        this.BulletsPerShot = bulletsPerShot;
        this.FireDelay = fireDelay;
        this.LoadedBulletType = loadedBulletType;
        CalculateSpread();
    }

    void Awake()
    {
    }

    public void setOwner(GameObject owner)
    {
        this.Owner = owner;
    }

    public GameObject GetBullet()
    {
        return BulletTypes[(int)LoadedBulletType];
    }

    public float GetDelay()
    {
        return this.FireDelay;
    }

    // returns directional vector opposite to shooting direction
    public Vector3 shoot(Vector3 direction, WeaponType type, Vector3 spawnPosition)
    {
        Vector3 force = new Vector3();

        // Assign weapon properties to type of weapon this is.
        CreateWeapon(type);

        for (int i = 0; i < BulletsPerShot; ++i)
        {
			GameObject bulletGO = (GameObject)Instantiate(BulletTypes[(int)LoadedBulletType], spawnPosition, Quaternion.Euler(0.0F, 0.90F, 0.0F));
			Bullet2 bullet = bulletGO.GetComponent<Bullet2>().Initialize();

			Quaternion facing = bulletGO.transform.rotation;
			Quaternion new_rot = Quaternion.LookRotation(direction);
			new_rot *= facing;
			bulletGO.transform.rotation = new_rot;

            

            bullet.setOwner(this.Owner);
            bullet.setOwnerId(this.Owner.GetComponent<Player>().getId());
            force += bullet.shoot(direction, SpreadAngles[i], LoadedBulletType);
        }

        return force;
    }

    private void CalculateSpread()
    {
        // If the spread is set to 0, set the angle array to zero as well (fire in a straight line).
        if(SpreadArc == 0)
        {
            float[] angles = new float[BulletsPerShot];
            angles[0] = 0.0F;
            this.SpreadAngles = angles;
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
