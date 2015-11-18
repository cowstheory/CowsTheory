using UnityEngine;
using System.Collections;

public class Xbox2 : Controller {

	void Update () {
		// TODO: Custom mapping for xbox controller 2
		Vector3 direction = new Vector3(Input.GetAxis("LeftJoystickX_P2"), -Input.GetAxis("LeftJoystickY_P2"), 0.0F);

		if (Input.GetAxis ("LeftTrigger_P2") > 0.5F && direction != new Vector3()) {
			p.fireGun (direction);
		}

		if(Input.GetButtonDown("A_P2") && direction != new Vector3()){
			p.fireGun (direction);
		}
	}
}
