using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Resources : NetworkBehaviour {

	[SyncVar] public float resource0 = 1000.0f;
	[SyncVar] public float resource1 = 0f;
	[SyncVar] public float resource2 = 0f;
	[SyncVar] public float resource3 = 0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		
	}


}
