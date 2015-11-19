public class Powerup {
  	public GameObject powerupGO;
	public int id;
	public float gravityFactor = 0F; // then tune this value  in editor too
	
	private GameObject blackHole;
	private Rigidbody rb;
	private Bullet bullet;
	private PhysicsBehaviour pb;
        
	public Powerup(){
	}
        
	void OnTriggerEnter(Collider other){
            if (other.tag == "Player") {
                Player pc = other.GetComponent<Player>();
                pc.givePowerup(this);
                Destroy(go);
            }
	}
}
