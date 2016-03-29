using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LocalNetworkSetup : NetworkBehaviour {

	[SerializeField] Camera FPSCharacterCam;
	[SerializeField] AudioListener audioListener;

	void Start () {
		if (isLocalPlayer) {
			
			//GetComponent<CharacterController>().enabled = true;
			//GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
			FPSCharacterCam.enabled = false;
			audioListener.enabled = false; 
		}
		if (isServer) {
			GameObject.Find("SceneCamera").SetActive(true);
			FPSCharacterCam.enabled = true;
		}
	}


}
