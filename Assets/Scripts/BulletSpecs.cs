using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BulletSpecs : NetworkBehaviour {

	//[SyncVar]
	//private float movementSpeed = 1000.0f;
	//public Vector3 firedFrom;

	// Use this for initialization
	void Start () {
		//firedFrom = this.transform.forward;
		transform.GetComponent<Rigidbody>().AddForce (transform.forward * 100.0f);
		//transform.GetComponent<Rigidbody>().AddForce(
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//if (!isServer) return;

	}

}
