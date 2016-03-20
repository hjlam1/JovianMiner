using UnityEngine;
using System.Collections;

public class joystickTest2 : MonoBehaviour {

	public GameObject ship;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//ship.transform.position = new Vector3 ( Input.GetAxis("X"), Input.GetAxis("Y"), Input.GetAxis("Z"));

		//Debug.Log (Input.GetAxis ("D"));

		
		//ship.transform.rotation = Quaternion.Euler (new Vector3( Input.GetAxis("D")*180.0f, 0f,0f));
	}
}
