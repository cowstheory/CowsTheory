using UnityEngine;
using System.Collections;

public class Keyboard1 : Controller {

	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireDelay;
			if (Input.GetKey(KeyCode.W)) {
				p.fireGun (Vector3.up, 0);
			}
			if (Input.GetKey (KeyCode.S)) {
				p.fireGun (Vector3.down, 0);
			}
			if (Input.GetKey (KeyCode.A)) {
				p.fireGun (Vector3.left, 0);
			}
			if (Input.GetKey (KeyCode.D)) {
				p.fireGun (Vector3.right, 0);
			}
		}
	}
}
