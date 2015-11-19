using UnityEngine;
using System.Collections;

public class Keyboard1 : Controller {
	void Update () {
		bool left, right, up, down;

		for (int i=0; i < 2; i++) {
			left = false;
			right = false;
			up = false;
			down = false;

			up =    Input.GetKey(i==0 ? KeyCode.W : KeyCode.T);
			down =  Input.GetKey(i==0 ? KeyCode.S : KeyCode.G);
			left =  Input.GetKey(i==0 ? KeyCode.A : KeyCode.F);
			right = Input.GetKey(i==0 ? KeyCode.D : KeyCode.H);

			if (up && down) {up = false; down = false;}
			if (left && right) {left = false; right = false;}

			float numPressed = (up?1.0F:0.0F) + (left?1.0F:0.0F)
				+ (right?1.0F:0.0F) + (down?1.0F:0.0F);

			float x = ((right?1.0F:0.0F) - (left?1.0F:0.0F)) / numPressed;
			float y = ((up?1.0F:0.0F) - (down?1.0F:0.0F)) / numPressed;


			if (numPressed > 0.0F && Time.time >= p.nextFire[i]) {
				nextFire = Time.time + fireDelay;
				if (p.fireGun((new Vector3(x, y, 0.0F)).normalized, i)) {
					p.nextFire[i] = Time.time + p.getDelayForWeapon(i);
				}
			}
		}
	}
}
