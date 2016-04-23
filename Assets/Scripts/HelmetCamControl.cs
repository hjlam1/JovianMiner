using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HelmetCamControl : NetworkBehaviour {

	private WebCamDevice[] camDevices;
	private WebCamTexture[] camTextures = new WebCamTexture[4];
	public RawImage OHImage1;
	public RawImage OHImage2;
	public RawImage OHImage3;
	public RawImage GHImage1;
	public RawImage GHImage2;
	public RawImage GHImage3;

	void Start () {
		camDevices = WebCamTexture.devices;
		Debug.Log("Cameras found: " + camDevices.Length);
		for (int i=0; i< camDevices.Length; i++) {
			
			camTextures[i] = new WebCamTexture(camDevices[i].name);
			camTextures[i].Play();
		}

		if (camDevices.Length >= 1) {
			OHImage1.texture = camTextures[0];
			OHImage1.material.mainTexture = camTextures[0];
			if (camDevices.Length >= 2) {
				OHImage2.texture = camTextures[1];
				OHImage2.material.mainTexture = camTextures[1];
				if (camDevices.Length >= 3) {
					GHImage1.texture = camTextures[2];
					OHImage1.material.mainTexture = camTextures[2];
					if (camDevices.Length >= 4) {
						GHImage2.texture = camTextures[3];
						GHImage2.material.mainTexture = camTextures[3];

					}
				}
			}
		}


	}
	
	void Update () {
	
	}
}
