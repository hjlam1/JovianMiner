using System;
using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.Networking;

public class SerialEulerA : NetworkBehaviour {

	SerialPort stream;
	public Quaternion direction;
	public GameObject gun;

	private AudioSource[] gunSound;
	//public GameObject lobbedObject;
	public rayShoot gunCode;
	public GameObject bullet_prefab;
	private float gunNextTime2 = 0.0f;
	private float gunInterval2 = 2.5f;
	private bool isPortChosen = false;
	private string[] portList;
	//private float lobSpeed = 20000.0f;
	
	void Start () {
		gunSound = gun.GetComponents<AudioSource>();
		portList= SerialPort.GetPortNames();
		for (int i = 0; i < portList.Length; i++) {
			Debug.Log (portList[i]);
		}

	}
	void OnGUI () {
		if (!isPortChosen) {
			for (int i = 0; i < portList.Length; i++) {
				if (GUI.Button (new Rect(20, 40 + (i * 30), 80, 20), portList[i])) {
					stream = new SerialPort(portList[i], 115200);
					isPortChosen = true;
				}
			}
		}
	}
	void Update () {
		if (isPortChosen) {
		try{
			stream.Open();
			string serialInput = stream.ReadLine();
						
			string[] strEul= serialInput.Split (',');
			if (strEul.Length > 5) {
				direction = Quaternion.Euler (new Vector3( -float.Parse(strEul[5]), float.Parse (strEul[3]), float.Parse(strEul[4])));
				this.transform.localRotation = direction;
				if (int.Parse(strEul[2]) == 1) {
					//Gunfire
					gunCode.Fire ();
					if (!gunSound[2].isPlaying) {
						gunSound[2].Play ();

					}
				} else {
					gunSound[2].Stop();
				}
				if ((int.Parse(strEul[1]) == 1) && (Time.time > gunNextTime2)) {
					//Gunfire 2
					Debug.Log ("Fire");
						CmdLobBullet();
					//CmdLobTheBullet();
					gunNextTime2 = Time.time + gunInterval2;
					gunSound[3].Play();

				}
			}
			//stream.BaseStream.Flush();
			stream.Close ();
		}
		catch(Exception e){
			Debug.Log("Could not open serial port: " + e.Message);
			isPortChosen = false;
			
		}
		}

	}

	IEnumerator SerialOperation() {

		while(true) {

			yield return null;
				
		}
	}
	[Command]
	
	public void CmdLobBullet() {
		GameObject obj = (GameObject) Instantiate (bullet_prefab, new Vector3(gun.transform.position.x, gun.transform.position.y, gun.transform.position.z), gun.transform.rotation);
		//BulletSpecs bullet = obj.GetComponent<BulletSpecs>();
		//bullet.firedFrom = -gun.transform.forward * lobSpeed;
		Destroy (obj, 5.0f);
		//Debug.Log ("CmdLobBullet called");
		//ClientScene.RegisterPrefab(obj);
		NetworkServer.Spawn (obj);
	}

	public void CmdLobTheBullet() {
		//lobbedObject.transform.localPosition = gun.transform.position;
		//lobbedObject.transform.rotation = gun.transform.rotation;
		//lobbedObject.GetComponent<BulletSpecs>().firedFrom = gun.transform.forward * lobSpeed;


	}
}

