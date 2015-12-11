using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public GameObject whirl;
	
	// Update is called once per frame
	void Update () {
		whirl.transform.Rotate (0, 0, 360 * Time.deltaTime);
	}
}
