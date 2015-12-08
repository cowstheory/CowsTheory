using UnityEngine;
using System.Collections;

public class Xbox2 : Controller {
	void Update () {
        Vector3 directionLeft, directionRight;
        
		directionLeft = new Vector3(Input.GetAxis("LeftJoystickX_P2"), -Input.GetAxis("LeftJoystickY_P2"), 0.0F);
		directionRight = new Vector3(Input.GetAxis("RightJoystickX_P2"), -Input.GetAxis("RightJoystickY_P2"), 0.0F);
        
        Game game = GameObject.FindObjectOfType<Game>();
        
        if (game.state == "menu") {
            if (Input.GetButtonDown("A_P2")) {
                game.state = "ingame";
            }
        } else if (game.state == "ingame") {
            if (directionLeft.magnitude > con.CONTROLLER_DEADZONE) {
                if (Time.time >= p.nextFire[0]) {
                    if (p.fireGun(directionLeft.normalized, 0)) {
                        p.nextFire[0] = Time.time + p.getDelayForWeapon(0);
                    }
                }
            }
            
            if (directionRight.magnitude > con.CONTROLLER_DEADZONE) {
                if (Time.time >= p.nextFire[1]) {
                    if (p.fireGun(directionRight.normalized, 1)) {
                        p.nextFire[1] = Time.time + p.getDelayForWeapon(1);
                    }
                }
            }
        }
	}
}
