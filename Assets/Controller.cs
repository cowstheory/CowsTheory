using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    // Update is called once per frame
    void Update () {
        if(Input.GetButtonDown("A")){
            Debug.Log("Button A");
        }

        if(Input.GetButtonDown("B")){
            Debug.Log("Button B");
        }

        if(Input.GetButtonDown("X")){
            Debug.Log("Button X");
        }

        if(Input.GetButtonDown("Y")){
            Debug.Log("Button Y");
        }
    }
}
