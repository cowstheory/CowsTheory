using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	
	private float shotgunSpreadAngle;

	private float[] shotgunAngles;
	private int shotgunBullets;
	private GameObject owner;

	void Start(){
		shotgunSpreadAngle = 45.0F;
		shotgunBullets = 5;
		shotgunAngles = calculateShotgunSpread ();
	}

	public void setOwner(GameObject owner){
		this.owner = owner;
	}
	
	// returns directional vector opposite to shooting direction
	public Vector3 shoot (Vector3 direction, WeaponType type, GameObject bulletGO){
		Vector3 force = new Vector3 ();

		// TODO: add more weapon types
		switch (type) {
			case WeaponType.MACHINEGUN:
				force = shootMachinegun(direction, bulletGO);
				break;	
			case WeaponType.SHOTGUN:
				force = shootShotgun(direction, bulletGO);
				break;
			default:
				break;
		}

		return force;
	}

	// TODO: shoot like a shotgun
	private Vector3 shootShotgun(Vector3 direction, GameObject bulletGO){
		Vector3 force = new Vector3 ();

		for (int i = 0; i < shotgunBullets; ++i) {
			Bullet bullet = ((GameObject)Instantiate(bulletGO, this.transform.position, new Quaternion())).GetComponent<Bullet>().Initialize();
			bullet.setOwner (this.owner);
			bullet.setOwnerId (this.owner.GetComponent<Player>().getId());
			force += bullet.shoot(direction, shotgunAngles[i]);
		}

		return force * 0.6F;
	}

	private Vector3 shootMachinegun(Vector3 direction, GameObject bulletGO){
		Bullet bullet = ((GameObject)Instantiate(bulletGO, this.transform.position, new Quaternion())).GetComponent<Bullet>().Initialize();
		bullet.setOwner (this.owner);
		bullet.setOwnerId (this.owner.GetComponent<Player>().getId());
		return bullet.shoot(direction, 0.0F);
	}

	public float[] calculateShotgunSpread(){
		float step = (shotgunSpreadAngle / (shotgunBullets - 1));
		float start = -(shotgunSpreadAngle / 2.0F);
		float[] angles = new float[shotgunBullets];

		for (int i = 0; i < shotgunBullets; ++i) {
			angles[i] = (start + i*step);
		}
		return angles;
	}
}
