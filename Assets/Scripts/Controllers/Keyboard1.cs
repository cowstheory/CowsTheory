using UnityEngine;
using System.Collections;

public class Keyboard1 : Controller {

	/*private float getFloatFromBool(bool b) {
		if (b) { return 1.0F; } else { 0.0F}
	}*/

	// Update is called once per frame
	void Update () {
		/*bool left = false;
		bool right = false;
		bool up = false;
		bool down = false;

		up = Input.GetKey(KeyCode.W);
		down = Input.GetKey(KeyCode.S);
		left = Input.GetKey(KeyCode.A);
		right = Input.GetKey(KeyCode.D);

		if (up && down) {up = false; down = false;}
		if (left && right) {left = false; right = false;}

		float numPressed = getFloatFromBool(up) + getFloatFromBool(left) +
			getFloatFromBool(right) + getFloatFromBool(down);
			*/
		/*float x = (float(right) - float(left)) / numPressed;
		float y = (float(right) - float(left)) / numPressed;


		if (numPressed > 0.0F && Time.time > this.nextFire) {
			nextFire = Time.time + fireDelay;
			p.fireGun(Vector3(x, y, 0.0F));
		}*/

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
