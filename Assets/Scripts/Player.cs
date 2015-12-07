using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	public GameObject playerGO, bulletGO;
	public int id;
	public float gravityFactor = 0F; // then tune this value  in editor too
    
	private GameObject blackHole;
	private Rigidbody rb;
	private Bullet bullet;
	private PhysicsBehaviour pb;
	private WeaponType[] currentWeapons;

	public Dictionary<WeaponType, GameObject> bulletTypes = new Dictionary<WeaponType, GameObject>();

	public GameObject[] gunBulletTypes;

	public float[] nextFire;

	public Text damageText;

	private Weapon weapon;

	void Start ()
	{
		weapon = GetComponent<Weapon> ();
		weapon.setOwner (playerGO);
		currentWeapons = new WeaponType[2];

		rb = playerGO.GetComponent<Rigidbody> ();
		pb = new PhysicsBehaviour (playerGO);
        
		this.rb.mass = 5.0F;
        
		nextFire = new float[2];
		nextFire [0] = Time.time;
		nextFire [1] = Time.time;

		currentWeapons [0] = WeaponType.MACHINEGUN;
		currentWeapons [1] = WeaponType.SHOTGUN;
		bulletTypes.Add (WeaponType.MACHINEGUN, gunBulletTypes [0]);
		bulletTypes.Add (WeaponType.SHOTGUN, gunBulletTypes [1]);
	}
    
	void FixedUpdate ()
	{
		pb.updatePhysics ();
	}
    
	public bool fireGun (Vector3 direction, int whichGun)
	{ //returns true if we could fire the gun, else false
		if (whichGun >= currentWeapons.Length) {
			Debug.Log ("Out of index when firing gun in Player.fireGun");
			return false;
		}
        
		rb.AddForce (weapon.shoot(direction, currentWeapons[whichGun], bulletTypes[currentWeapons[whichGun]]));
        
		return true;
        
	}
    
	public float getDelayForWeapon (int whichGun)
	{
		if (whichGun >= gunBulletTypes.Length) {
			Debug.Log ("Out of index when trying to get delay for weapon");
			return 0.0F;
		}
        
		//TODO: use gunBulletTypes[whichGun] instead
		return 0.2F;
	}

	public void takeDamage (float damage)
	{
		pb.addGravityFactor (damage);
		if (this.GetComponent<TextMesh> () != null)
			this.GetComponent<TextMesh> ().text = pb.getGravityFactorText ();
//		damageText.text = "" + gravityFactor + "%";
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.name == "BLACKHOLE") {
			rb.Sleep ();
			playerGO.transform.position = Random.insideUnitCircle * Random.Range (10, 20);
			rb.WakeUp ();
			rb.velocity = Vector3.up * 5.0F;
			this.gravityFactor = 0.0F;
//			damageText.text = "" + gravityFactor + "%";
		} else if (other.tag == "Bullet") {

			Bullet b = other.GetComponent<Bullet> ();
			if (b.getOwnerId () != this.id) {
				//m1v1 = m2v2 => v1 = m2v2/m1 = (m2/m1)v2
				rb.velocity += con.BULLET_COLLISION_MULTIPLIER *
					(other.attachedRigidbody.mass / this.rb.mass) * other.attachedRigidbody.velocity;
			}
		}
	}
    
	public int getId(){
		return id;
	}

	public void receievePowerup (Powerup pu)
	{
		/*switch (pu.type) {
            case "shotspeedup":
                break;
            case "health":
                break;
            default:
                Debug.Log(String.Format("%s is not a valid powerup type!", type));
                return;
        }
        */
	}
}
