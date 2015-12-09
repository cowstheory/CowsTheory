using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	public GameObject spine;
	public int id;
	public float gravityFactor = 0F; // then tune this value  in editor too
	private Game game;
	private Rigidbody rb;
	private PhysicsBehaviour pb;
	private WeaponType[] currentWeapons;
	
	private GameObject upperLeftArm, leftHand;
	private GameObject upperRightArm, rightHand;
	
	public AudioClip[] audioClips;
	public AudioSource[] weaponFireSources;
	//public GameObject[] gunBulletTypes;

	private float[] nextFire;

//	public Text damageText;

	private Weapon2 weapon;

	void Awake ()
	{	
		weapon = GetComponent<Weapon2> ();
        weapon.setOwner (spine);
		currentWeapons = new WeaponType[2];
		game = FindObjectOfType<Game> ();
		rb = spine.GetComponent<Rigidbody> ();
		pb = new PhysicsBehaviour (spine);
        
		this.rb.mass = 5.0F;
        
		nextFire = new float[2];
		nextFire [0] = Time.time;
		nextFire [1] = Time.time;

		weaponFireSources = spine.GetComponents<AudioSource> ();

//		weaponFireSources [0].clip = audioClips [1];
//		weaponFireSources [1].clip = audioClips [2];

		currentWeapons [0] = WeaponType.MACHINEGUN;
		currentWeapons [1] = WeaponType.SHOTGUN;

		upperLeftArm = spine.transform.Find ("chest/shoulder.L/upper_arm.L").gameObject;
		upperRightArm = spine.transform.Find ("chest/shoulder.R/upper_arm.R").gameObject;

		leftHand = upperLeftArm.transform.Find ("forearm.L/hand.L").gameObject;
		rightHand = upperRightArm.transform.Find ("forearm.R/hand.R").gameObject;

	}
    
	void FixedUpdate ()
	{
		pb.updatePhysics ();
	}
    
	public float getNextFire(int i){
		if (i < nextFire.Length)
			return nextFire [i];
		else
			Debug.Log ("Out of index when accessing nextFire");
			return 0;
	}

	public void setNextFire(int index, float val){
		if (index < nextFire.Length)
			nextFire [index] = val;
		else
			Debug.Log ("Out of index when accessing nextFire");
	}

	public bool fireGun (Vector3 direction, int whichGun)
	{ //returns true if we could fire the gun, else false
		if (whichGun >= currentWeapons.Length) {
			Debug.Log ("Out of index when firing gun in Player.fireGun");
			return false;
		}
		Vector3 position;
		if (whichGun == 0) {
			position = leftHand.transform.position;
		} else {
			position = rightHand.transform.position;
		}
		position.z = 0;
        Vector3 force = weapon.shoot(direction, currentWeapons[whichGun], position);
        rb.AddForce (force);
		Debug.DrawLine (spine.transform.position, (spine.transform.position + 10*direction), Color.red);        

//		weaponFireSources [whichGun].Play ();

		return true;
        
	}

	void Update(){
//		Debug.Log (upperRightArm.transform.forward);
		Debug.DrawLine (upperRightArm.transform.position, upperRightArm.transform.position + upperRightArm.transform.forward, Color.blue);
		Debug.DrawLine (upperRightArm.transform.position, upperRightArm.transform.position + upperRightArm.transform.right, Color.red);
		Debug.DrawLine (upperRightArm.transform.position, upperRightArm.transform.position + upperRightArm.transform.up, Color.green);
	}
    
	public float getDelayForWeapon (int whichGun)
	{
        return 0.2F;
        //return weapon.GetDelay();
    }

	public void takeDamage (float damage)
	{
		pb.addGravityFactor (damage);
//		if (this.GetComponent<TextMesh> () != null)
//			this.GetComponent<TextMesh> ().text = pb.getGravityFactorText ();
//		damageText.text = "" + gravityFactor + "%";
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.name == "BLACKHOLE") {
			rb.Sleep ();
			rb.WakeUp();
			game.destroyPlayer(this.id);
//			game.instantiatePlayer(this.id);
//			Destroy (this);

//			spine.transform.position = Random.insideUnitCircle * Random.Range (30, 40);
//			rb.WakeUp ();
//			rb.velocity = Vector3.up * 5.0F;
//			this.gravityFactor = 0.0F;
//			damageText.text = "" + gravityFactor + "%";
		} else if (other.tag == "Bullet") {

			Bullet2 b = other.GetComponent<Bullet2> ();
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

	public void rotateArms(Vector3 direction) {
		Debug.Log (upperLeftArm.transform.rotation);
	}

    public void receievePowerup(PowerupType type) {
        //TODO: Add the powerup to our list of powerups
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
