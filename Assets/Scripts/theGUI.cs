using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class theGUI : NetworkBehaviour {

	public Resources myStuff;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (isServer) {
			//GUI.Box (new Rect(200,0,80,20), myStuff.resource0.ToString());
			//GUI.Box (new Rect(200,20,80,20), myStuff.resource1.ToString());
			//GUI.Box (new Rect(200,40,80,20), myStuff.resource2.ToString());
			//GUI.Box (new Rect(200,60,80,20), myStuff.resource3.ToString());
			//GUI.Box (new Rect(200,80,80,20), myStuff.resource4.ToString());
			//GUI.Box (new Rect(200,100,80,20), myStuff.normal.ToString());
		}
	}
}
