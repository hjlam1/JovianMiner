﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	[SerializeField] Camera FPSCharacterCam;
	[SerializeField] AudioListener audioListener;

	void Start () {
		if (isLocalPlayer) {
			GameObject.Find("SceneCamera").SetActive(false);
			//GetComponent<CharacterController>().enabled = true;
			//GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
			FPSCharacterCam.enabled = true;
			audioListener.enabled = true; 
		}

	}


}