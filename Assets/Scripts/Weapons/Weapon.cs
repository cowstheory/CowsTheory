using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	
	private float shotgunSpreadAngle;

	private float[] shotgunAngles;
	private int shotgunBullets;
	private GameObject owner;

	void Awake(){
		shotgunSpreadAngle = 25.0F;
		shotgunBullets = 7;
		shotgunAngles = calculateShotgunSpread ();
	}

	public void setOwner(GameObject owner){
		this.owner = owner;
	}
	
	// returns directional vector opposite to shooting direction
	public Vector3 shoot (Vector3 direction, WeaponType type, Vector3 spawnPosition, GameObject bulletGO){
		Vector3 force = new Vector3 ();

		// TODO: add more weapon types
		switch (type) {
			case WeaponType.MACHINEGUN:
				force = shootMachinegun(direction, spawnPosition, bulletGO);
				break;
			case WeaponType.SHOTGUN:
				force = shootShotgun(direction, spawnPosition, bulletGO);
				break;
			default:
				break;
		}

		return force;
	}

	// TODO: shoot like a shotgun
	private Vector3 shootShotgun(Vector3 direction, Vector3 spawnPosition, GameObject bulletGO){
		Vector3 force = new Vector3 ();

		for (int i = 0; i < shotgunBullets; ++i) {
			Bullet bullet = ((GameObject)Instantiate(bulletGO, spawnPosition, new Quaternion())).GetComponent<Bullet>().Initialize();
			bullet.setOwnerId (this.owner.GetComponent<Player>().getId());
			force += bullet.shoot(direction, shotgunAngles[i]);
		}

		return force / shotgunBullets;
	}

	private Vector3 shootMachinegun(Vector3 direction, Vector3 spawnPosition, GameObject bulletGO){
		Bullet bullet = ((GameObject)Instantiate(bulletGO, spawnPosition, new Quaternion())).GetComponent<Bullet>().Initialize();
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
