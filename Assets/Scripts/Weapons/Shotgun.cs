using UnityEngine;
using System.Collections;

public class Shotgun : Weapon {

	void Start(){
		this.fireRate = 0.6F;
		this.numberOfBullets = 5;
		this.lifeSpan = 0.5F;
		this.spawnTime = Time.time;
		this.spreadAngle = 45.0F;
		calculateSpread ();
	}

	public override Vector3 shoot(Vector3 direction){
		Vector3 force = new Vector3();

		for (int i = 0; i < numberOfBullets; ++i) {
			Bullet b = bullets[i].GetComponent<Bullet>();
			force += b.shoot(Quaternion.Euler(0.0F, angles[i], 0.0F) * direction);

		}
		return force;
	}

	void Update () {
		if (Time.time > (spawnTime + lifeSpan)) {
			foreach(GameObject bullet in bullets){
				Destroy (bullet);
			}
		}
	}
}
