using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class HelmetCam : NetworkBehaviour {

	WebCamDevice[] camDevices;

	// Use this for initialization
	void Start () {
		camDevices = WebCamTexture.devices;
		for (int i=0; i< camDevices.Length; i++) {
			Debug.Log(camDevices[i].name);
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
