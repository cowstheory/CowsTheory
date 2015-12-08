using System;

public class WeaponMaker
{
    public enum WeaponType { SHOTGUN, MACHINEGUN};
    public enum BulletType { MINOR, HEAVY, EXPLOSIVE};
    private Weapon2[] Weapons;
    private Bullet2[] Bullets;

	public WeaponMaker()
	{
        Bullets[(int)BulletType.MINOR] = new Bullet2(0.1F, 10.0F, 30.0F, 2.0F);
        Bullets[(int)BulletType.HEAVY] = new Bullet2(0.2F, 20.0F, 15.0F, 4.0F);
        Bullets[(int)BulletType.EXPLOSIVE] = new Bullet2(0.1F, 15.0F, 10F, 4.0F);

        Weapons[(int)WeaponType.SHOTGUN] = new Weapon2(25F, 7);
        Weapons[(int)WeaponType.MACHINEGUN] = new Weapon2(0F, 1);
    }

    public Weapon2[] GetWeapons()
    {
        return Weapons;
    }

    public Bullet2[] GetBullets()
    {
        return Bullets;
    }
}
