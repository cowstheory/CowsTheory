using UnityEngine;
using System.Collections;

public class Xbox1 : Controller {
	void Update () {
        Vector3 direction;
        for (int i=0; i < 2; i++) {
            if (i == 0) {
                direction = new Vector3(Input.GetAxis("LeftJoystickX_P1"), -Input.GetAxis("LeftJoystickY_P1"), 0.0F);
            } else {
                direction = new Vector3(Input.GetAxis("RightJoystickX_P1"), -Input.GetAxis("RightJoystickY_P1"), 0.0F);
            }
            
            if (direction.magnitude > con.CONTROLLER_DEADZONE) {
                if (Time.time >= p.nextFire[i]) {
                    if (p.fireGun(direction.normalized, i)) {
                        p.nextFire[i] = Time.time + p.getDelayForWeapon(i);
                    }
                }
            }
        }
	}
}
