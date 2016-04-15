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
		//GUI.Box (new Rect(200,0,100,50), myStuff.resource0.ToString());
		//GUI.Box (new Rect(200,40,100,50), myStuff.resource1.ToString());
		//GUI.Box (new Rect(200,80,100,50), myStuff.resource2.ToString());
		//GUI.Box (new Rect(200,120,100,50), myStuff.normal.ToString());
	}
}
