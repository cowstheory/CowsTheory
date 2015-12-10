using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	public GameObject spine;
	public int id;
	private Game game;
	private Rigidbody rb;
	private PhysicsBehaviour pb;
	private WeaponType[] currentWeapons;
	
	private GameObject upperLeftArm, leftHand;
	private GameObject upperRightArm, rightHand;
	
	public AudioClip[] audioClips;
	public AudioSource[] weaponFireSources;

	private float[] nextFire;

	private Weapon2 weapon;

//	private Text damageText;
	private TextMesh damageText;

	void Awake ()
	{	

        //Debug.Log (GameObject.Find("Player" + id + "_text/damage" + id).GetComponent<TextMesh> ().text);

        this.damageText = GameObject.Find("Player" + id + "_text/damage" + id).GetComponent<TextMesh> ();

        Debug.Log (this.damageText.text);
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

		weaponFireSources [0].clip = audioClips [0];
		weaponFireSources [1].clip = audioClips [1];

		weaponFireSources [0].volume = 0.065F;
		weaponFireSources [1].volume = 0.065F;

		currentWeapons [0] = WeaponType.MACHINEGUN;
		currentWeapons [1] = WeaponType.SHOTGUN;

		upperLeftArm = spine.transform.Find ("chest/shoulder.L/upper_arm.L").gameObject;
		upperRightArm = spine.transform.Find ("chest/shoulder.R/upper_arm.R").gameObject;

		leftHand = upperLeftArm.transform.Find ("forearm.L/hand.L").gameObject;
		rightHand = upperRightArm.transform.Find ("forearm.R/hand.R").gameObject;

	}
    
	void Start(){
		this.damageText.text = "Damage: " + this.pb.getGravityFactorText ();
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

//		Debug.Log ("whichGun:" + whichGun);
		position.z = 0;
        Vector3 force = weapon.shoot(direction, currentWeapons[whichGun], position);
        rb.AddForce (force);
//		Debug.DrawLine (spine.transform.position, (spine.transform.position + 10*direction), Color.red);

		weaponFireSources [whichGun].Play ();

		return true;
        
	}

//	void Update(){
//		Debug.Log (upperRightArm.transform.forward);
//		Debug.DrawLine (upperRightArm.transform.position, upperRightArm.transform.position + upperRightArm.transform.forward, Color.blue);
//		Debug.DrawLine (upperRightArm.transform.position, upperRightArm.transform.position + upperRightArm.transform.right, Color.red);
//		Debug.DrawLine (upperRightArm.transform.position, upperRightArm.transform.position + upperRightArm.transform.up, Color.green);
//	}
    
	public float getDelayForWeapon (int whichGun)
	{
//        return 0.2F;
        return weapon.GetDelay();
    }

	public void takeDamage (float damage)
	{
		pb.addGravityFactor (damage);
		damageText.text = "Damage: " + this.pb.getGravityFactorText();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.name == "BLACKHOLE") {
			rb.Sleep ();
			rb.WakeUp();
			game.destroyPlayer(this.id);
			damageText.text = "Damage: " + this.pb.getGravityFactorText() + "%";
		} else if (other.tag == "Bullet") {

			Bullet2 b = other.GetComponent<Bullet2> ();
			if (b.getOwnerId () != this.id) {
				//m1v1 = m2v2 => v1 = m2v2/m1 = (m2/m1)v2
				rb.velocity += con.BULLET_COLLISION_MULTIPLIER *
					(other.attachedRigidbody.mass / this.rb.mass) *
                    other.attachedRigidbody.velocity *
                    this.pb.getGravityFactor(); //pushed away further if we have a higher gf
			}
		}
	}
    
	public int getId(){
		return id;
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
