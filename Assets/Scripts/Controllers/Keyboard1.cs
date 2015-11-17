using UnityEngine;
using System.Collections;

public class Keyboard1 : Controller {

	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireDelay;
			if (Input.GetKey(KeyCode.W)) {
				p.fireGun (Vector3.up);
			}
			if (Input.GetKey (KeyCode.S)) {
				p.fireGun (Vector3.down);
			}
			if (Input.GetKey (KeyCode.A)) {
				p.fireGun (Vector3.left);
			}
			if (Input.GetKey (KeyCode.D)) {
				p.fireGun (Vector3.right);
			}
		}
	}
}
