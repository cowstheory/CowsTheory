using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

	public float fireRate;
	public GameObject[] bullets;
	public float spreadAngle;

	protected float[] angles;
	protected float lifeSpan, spawnTime;
	protected int numberOfBullets;
	protected GameObject owner;

	public void setOwner(GameObject owner){
		this.owner = owner;
	}

	public abstract Vector3 shoot (Vector3 direction);

	public void calculateSpread(){
		float step = (spreadAngle / (numberOfBullets - 1));
		float start = -(spreadAngle / 2.0F);
		angles = new float[numberOfBullets];

		for (int i = 0; i < numberOfBullets; ++i) {
			angles[i] = start + i*step;
		}
	}

}
