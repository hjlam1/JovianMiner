using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerID : NetworkBehaviour {

	private GameObject[] users;// = GameObject.FindGameObjectsWithTag("Player");

	[SyncVar] public string playerUniqueIdentity;
	private NetworkInstanceId playerNetID;
	private Transform myTransform;

	public Transform GH;
	public Transform OHR;

	public override void OnStartLocalPlayer(){
		GetNetIdentity();
		SetIdentity();
		SetPair();


	}

	void OnPreRender() {
		GL.wireframe = true;
	}

	void Awake () {
		myTransform = transform;
		//Screen.SetResolution(768,1366, true);
	}
	
	void Update () {
		if(myTransform.name == "" || myTransform.name == "PlayerX(Clone)") {
			SetIdentity();
		}

	}

	void OnDisconnectedFromServer(NetworkDisconnection info) {
		if (Network.isServer)
			Debug.Log("Local server connection disconnected");
		else
			if (info == NetworkDisconnection.LostConnection)
				Debug.Log("Lost connection to the server");
		else
			Debug.Log("Successfully diconnected from the server");
	}

	[Client]
	void GetNetIdentity() {
		playerNetID = GetComponent<NetworkIdentity>().netId;
		CmdTellServerMyIdentity(MakeUniqueIdentity());
	}

	void SetIdentity() {
		if (!isLocalPlayer) {
			myTransform.name = playerUniqueIdentity;
		} else {

			myTransform.name = MakeUniqueIdentity();
			//Debug.Log ((int)playerNetID.Value);
		}
	}

	void ClientSetPair(GameObject child, GameObject parent) {
		Debug.Log ("ClientSetPair");
		child.GetComponentInChildren<MeshRenderer>().enabled = false;
		child.transform.parent = parent.transform;
		child.transform.rotation = Quaternion.identity;
		child.transform.localPosition = new Vector3 (0f, 3.0f, 0f);
	}

	string MakeUniqueIdentity() {
		string uniqueName;
		//if (GameObject.FindGameObjectsWithTag("Player").Length == 1) {
		//	uniqueName = "GuangHua";
		//} else if ((GameObject.FindGameObjectsWithTag("Player").Length == 2) || (GameObject.FindGameObjectsWithTag("Player").Length == 4)){
		//	uniqueName = "Gunner " + playerNetID.ToString();
		//} else if (GameObject.FindGameObjectsWithTag("Player").Length == 3) {
		//	uniqueName = "OHR";
		//} else {
		//	uniqueName = "Spectator " + playerNetID.ToString();
		//}
		//return uniqueName;
		if (GameObject.FindGameObjectsWithTag("Player").Length == 1) {
			uniqueName = "Gunner GuangHua";
		} else if (GameObject.FindGameObjectsWithTag("Player").Length == 2) {
			uniqueName = "Gunner OHR";
		} else {
			uniqueName = "Spectator " + playerNetID.ToString();
		}
		return uniqueName;
	}

	void SetPair() {
		users = GameObject.FindGameObjectsWithTag("Player");
		Debug.Log ("Number of PlayerX objects: " + users.Length);
		if (users.Length == 1) {
			//CmdSetPair(users[1], users[0]);
			//myTransform.GetComponentInChildren<MeshRenderer>().enabled = false;
			users[0].transform.parent = GH;
			users[0].transform.rotation = Quaternion.identity;
			users[0].transform.localPosition = new Vector3 (0f, 1.0f, 0f);
			if (isLocalPlayer) {
				Debug.Log ("Client 2: " + users[0].name);
				users[0].GetComponent<joystickTest>().enabled = false;
				users[0].GetComponent<CharacterController>().enabled = false;
				users[0].GetComponent<SerialEulerA>().enabled = true;
			}

		} else if (users.Length == 4) {
			myTransform.parent = OHR;
			myTransform.rotation = Quaternion.identity;
			myTransform.localPosition = new Vector3 (0f, 1.0f, 0f);
			if (isLocalPlayer) {
				Debug.Log ("Client 4: " + users[1].name);
				users[1].GetComponent<joystickTest>().enabled = false;
				users[1].GetComponent<CharacterController>().enabled = false;
				//users[1].GetComponent<MeshRenderer>().enabled = false;
				users[1].GetComponent<SerialEulerA>().enabled = true;
			}
		}
	}

	[Command]
	void CmdTellServerMyIdentity(string name) {
		playerUniqueIdentity = name;
	}

	void CmdSetPair(GameObject theChild, GameObject theParent){
		Debug.Log ("CmdSetPair");
		ClientSetPair (theChild, theParent);
		theChild.GetComponentInChildren<MeshRenderer>().enabled = false;
		theChild.transform.parent = theParent.transform;
		theChild.transform.rotation = Quaternion.identity;
		theChild.transform.localPosition = new Vector3 (0f, 3.0f, 0f);

	}

}