using UnityEngine;
using System.Collections;

public class Xbox2 : Controller {

	void Update () {
		// TODO: Custom mapping for xbox controller 2
		Vector3 direction = new Vector3(Input.GetAxis("LeftJoystickX"), -Input.GetAxis("LeftJoystickY"), 0.0F);
		if(Input.GetButtonDown("A") && direction != new Vector3()){
			p.fireGun (direction, 0);
		}
                
		Vector3 direction = new Vector3(Input.GetAxis("RightJoystickX"), -Input.GetAxis("RightJoystickY"), 0.0F);
		if(Input.GetButtonDown("A") && direction != new Vector3()){
			p.fireGun (direction, 1);
		}
	}
}
