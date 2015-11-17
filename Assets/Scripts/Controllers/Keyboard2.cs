using UnityEngine;
using System.Collections;

public class Keyboard2 : Controller {

	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireDelay;
			if (Input.GetKey (KeyCode.UpArrow)) {
				p.fireGun (Vector3.up);
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				p.fireGun (Vector3.down);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				p.fireGun (Vector3.left);
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				p.fireGun (Vector3.right);
			}
		}
	}
}
