using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GunnerSetup : NetworkBehaviour {

	//private GameObject[] users;// = GameObject.FindGameObjectsWithTag("Player");

	//[SyncVar] public string playerUniqueIdentity;
	//private NetworkInstanceId playerNetID;
	//private Transform myTransform;

	[SerializeField] Camera FPSCharacterCam;
	[SerializeField] AudioListener audioListener;

	public GameObject GH;
	public GameObject OHR;


	public override void OnStartLocalPlayer() {
		//Debug.Log ("OnStartLocalPlayer()");
	}

	void Awake () {
		
		GH = GameObject.Find("GuangHua");
		OHR = GameObject.Find("OnyxHill");
		//Screen.SetResolution(768,1366, true);
	}

	void Start() {
		
		if (isLocalPlayer) {
			GameObject.Find("SceneCamera").SetActive(false);
			GameObject.Find("GHCam").SetActive(false);
			GameObject.Find("OHRCam").SetActive(false);

			this.GetComponent<SerialB>().enabled = true;
			FPSCharacterCam.enabled = true;
			audioListener.enabled = true;

		}
		if (GameObject.FindGameObjectsWithTag("Gunner").Length == 1) {
			ClientSetPair(this.gameObject, GH);
		}
		if (GameObject.FindGameObjectsWithTag("Gunner").Length == 2) {
			ClientSetPair(this.gameObject, OHR);
		}
	}

	void Update () {
		
	}
		
		[Client]
	void GetNetIdentity() {
		//playerNetID = GetComponent<NetworkIdentity>().netId;
		//CmdTellServerMyIdentity(MakeUniqueIdentity());
	}

	void ClientSetPair(GameObject child, GameObject parent) {
		Debug.Log ("ClientSetPair");
		//child.GetComponentInChildren<MeshRenderer>().enabled = false;
		child.transform.parent = parent.transform;
		child.transform.rotation = Quaternion.identity;
		child.transform.localPosition = new Vector3 (0f, 2.0f, 0f);
	}




	[Command]
	void CmdTellServerMyIdentity(string name) {
		//playerUniqueIdentity = name;
	}
		

}