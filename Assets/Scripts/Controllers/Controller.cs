using UnityEngine;
using System.Collections;

public abstract class Controller : MonoBehaviour {

	protected GameObject playerGO;
	protected Player p;
	protected float nextFire = 0.0f;
	protected float fireDelay = 0.4F;

	public void setPlayerGO(GameObject go){
		this.playerGO = go;
		p = playerGO.GetComponent<Player> ();
	}
}
