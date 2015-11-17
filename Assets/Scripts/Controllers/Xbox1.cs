using UnityEngine;
using System.Collections;

public class Xbox1 : Controller {

	void Update () {
		// TODO: Custom mapping for xbox controller 1 
		Vector3 direction = new Vector3(Input.GetAxis("LeftJoystickX"), -Input.GetAxis("LeftJoystickY"), 0.0F);
		if(Input.GetButtonDown("A") && direction != new Vector3()){
			p.fireGun (direction);
		}
	}
}
