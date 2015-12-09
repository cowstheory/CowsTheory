using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour{
	int gameTime;

    public string state;
    
	public float width, height, hWidth, hHeight;

    public float blackHoleSize = con.BLACK_HOLE_START_SIZE;

//	private List<GameObject> player_objects;
	public List<GameObject> powerupObjects;

	public GameObject player1, player2;

	private Dictionary<int, GameObject> playerGameObjects;
	private Dictionary<int, GameObject> players;
	private Dictionary<int, Controller> xbox;
	private Dictionary<int, Controller> keyboards;
	private Controller keyboardController1, keyboardController2, xboxController1, xboxController2;

    private float delayBetweenPowerup = con.INITIAL_POWERUP_SPAWN_DELAY;
    private float timeOfNextPowerup;

	void Awake(){
		playerGameObjects = new Dictionary<int, GameObject> ();
		players = new Dictionary<int, GameObject> ();
		xbox = new Dictionary<int, Controller> ();
		keyboards = new Dictionary<int, Controller> ();

        state = "menu";
//		player_objects = new List<GameObject>();
		powerupObjects = new List<GameObject>();

		timeOfNextPowerup = Time.time;

		width = 50.0F;
		height = 50.0F;
		hHeight = width / 2.0F;
		hWidth = height / 2.0F;

        xboxController1 = GameObject.Find ("XboxController1").GetComponent<Controller>();
        xboxController2 = GameObject.Find ("XboxController2").GetComponent<Controller>();

        keyboardController1 = GameObject.Find ("KeyboardController1").GetComponent<Controller> ();
        keyboardController2 = GameObject.Find ("KeyboardController2").GetComponent<Controller> ();
		int player1id = player1.transform.Find ("metarig/hips/spine").GetComponent<Player>().getId();
		int player2id = player2.transform.Find ("metarig/hips/spine").GetComponent<Player>().getId();

		playerGameObjects.Add (player1id, player1);
		xbox.Add (player1id, xboxController1);
		keyboards.Add (player1id, keyboardController1);

		playerGameObjects.Add (player2id, player2);
		xbox.Add (player2id, xboxController2);
		keyboards.Add (player2id, keyboardController2);

		instantiatePlayer (player1id);
		instantiatePlayer (player2id);

//        GameObject p1 = (GameObject)Instantiate(player1);
//        GameObject p2 = (GameObject)Instantiate(player2);
//		GameObject p1_hips = player1.transform.Find ("metarig/hips/spine").GetComponent<Player>().getId();
//		GameObject p2_hips = player2.transform.Find ("metarig/hips/spine").gameObject;
//
//        xboxController1.setPlayerGO (p1_hips);
//        xboxController2.setPlayerGO (p2_hips);
//
//        keyboardController1.setPlayerGO (p1_hips);
//        keyboardController2.setPlayerGO (p2_hips);
//
//        p1.transform.position = new Vector3 (-10,10,0);
//        p2.transform.position = new Vector3 (10,10,0);
//        player_objects.Add(p1);
//        player_objects.Add(p2);
	}

	public void destroyPlayer(int id){
		GameObject player = players [id];
		players.Remove (id);
		Destroy (player);
		instantiatePlayer (id);
	}

	public void instantiatePlayer (int id){
		GameObject player = (GameObject)Instantiate (playerGameObjects[id]);
		GameObject playerHips = player.transform.Find ("metarig/hips/spine").gameObject;
		xbox[id].setPlayerGO(playerHips);
		keyboards [id].setPlayerGO (playerHips);

		player.transform.position = Random.insideUnitCircle * Random.Range (20, 25);
		players.Add (id, player);
	}

	void Update(){
        if (state == "menu") {
        } else if (state == "ingame") {
            if (Input.GetKeyDown (KeyCode.R)) {

//                foreach(GameObject p in player_objects){
//                    Rigidbody rb = p.GetComponent<Rigidbody>();
//                    rb.Sleep();
//                    p.transform.position = Random.insideUnitCircle * Random.Range (30, 40);
//                    rb.WakeUp();
//                }
            }
            handlePowerups();
        } else {
            Debug.Log("Unknown state '" + state + "'");
        }
	}

    public void handlePowerups() {
        if (Time.time >= timeOfNextPowerup){
            //create new powerup
            //Bullet2 bullet = ((GameObject)Instantiate(BulletTypes[(int)LoadedBulletType], spawnPosition, new Quaternion())).GetComponent<Bullet2>().Initialize();
//            Debug.Log("Pretend-created powerup!11");
			int index = Random.Range (0, powerupObjects.Count);

			Instantiate (powerupObjects[index], new Vector3(20,20,0), new Quaternion());
            timeOfNextPowerup = Time.time + delayBetweenPowerup;
        }    
    }

    public void reset() {
		// TODO: Actually reset the game
//        Debug.Log("Game was reset!");
    }

    public void update() {
        gameTime += 1;
        // float dt = 1/60;

        /*#Quicker gameplay: continously increase all player's gravityFactor
        #if this.gameTime % 15 == 0:
        #    for player in this.players:
        #        player.po.gravityFactor += 0.01*/

        //if (this.gameTime > 1 && this.gameTime % con.POWERUP_SPAWN_DELAY == 0) {
		if (Input.GetKeyDown(KeyCode.P)) {
			if (Random.Range(0.0F, 1.0F) > 0.5F) {
				//GameObject puo = (GameObject)Instantiate(ShotSpeedUPowerup);
			} else {
				//GameObject puo = (GameObject)Instantiate(otherPowerUp);
			}
			//this.powerup_objects.Add(puo);
        }

        /* TODO: remove players that are out of lives (same as just above this)
        //this.players = filter(lambda x: x.livesLeft > 0, this.players)*/
    }

}
