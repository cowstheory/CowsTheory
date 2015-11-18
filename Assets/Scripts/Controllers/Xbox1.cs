using UnityEngine;
using System.Collections;

public class Xbox1 : Controller {

	void Update () {
		// TODO: Custom mapping for xbox controller 1 
		Vector3 direction = new Vector3(Input.GetAxis("LeftJoystickX_P1"), -Input.GetAxis("LeftJoystickY_P1"), 0.0F);

		if (Input.GetAxis ("LeftTrigger_P1") > 0.0F && direction != new Vector3()) {
			p.fireGun (direction);
		}

		if(Input.GetButtonDown("A_P1") && direction != new Vector3()){
			p.fireGun (direction);
		}
	}
}
