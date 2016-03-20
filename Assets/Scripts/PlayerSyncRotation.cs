using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class PlayerSyncRotation : NetworkBehaviour {

	[SyncVar] private Quaternion syncPlayerRotation;
	[SyncVar] private Quaternion syncCamRotation;

	[SerializeField] private Transform playerTransform;
	[SerializeField] private Transform camTransform;
	[SerializeField] private float lerpRate = 15.0f;

	private Quaternion lastPlayerRotation;
	private Quaternion lastCamRotation;
	private float threshold = 5.0f;

	void Start () {
	
	}
	
	void Update () {
		TransmitRotations();
		LerpRotations ();
	
	}
	void LerpRotations() {
		if (!isLocalPlayer) {
			playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, syncPlayerRotation, Time.deltaTime * lerpRate);
			camTransform.rotation = Quaternion.Lerp(camTransform.rotation, syncCamRotation, Time.deltaTime * lerpRate);
		}
	}

	[Command]
	void CmdProvideRotationToServer (Quaternion playerRot, Quaternion camRot) {
		syncPlayerRotation = playerRot;
		syncCamRotation = camRot;
	}

	[Client]
	void TransmitRotations() {
		if (isLocalPlayer && (Quaternion.Angle (playerTransform.rotation, lastPlayerRotation)>threshold || Quaternion.Angle(camTransform.rotation, lastCamRotation) > threshold)) {
			CmdProvideRotationToServer(playerTransform.rotation, camTransform.rotation);
			lastPlayerRotation = playerTransform.rotation;
			lastCamRotation = camTransform.rotation;
		}
	}

}
