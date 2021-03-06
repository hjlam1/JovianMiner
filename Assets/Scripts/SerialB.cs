﻿using System;
using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.Networking;

public class SerialB : NetworkBehaviour {

	SerialPort stream;
	public Quaternion direction;
	public GameObject gun;

	private AudioSource[] gunSound;
	//public GameObject lobbedObject;
	public rayShoot gunCode;
	public GameObject bullet_prefab;
	public GameObject materialLocation;
	private float gunNextTime2 = 0.0f;
	private float gunInterval2 = 2.5f;
	private bool isPortChosen = false;
	private float gunLobCost = 2.0f;
	private string[] portList;
	private Resources myResources;
	//private float lobSpeed = 20000.0f;

	void Start () {
		if (SystemInfo.supportsGyroscope) {
			Debug.Log("Gyroscope Found!");
		}
		gunSound = gun.GetComponents<AudioSource>();
		portList= SerialPort.GetPortNames();
		for (int i = 0; i < portList.Length; i++) {
			Debug.Log (portList[i]);
		}
		myResources = this.GetComponentInParent<Resources>();
	}
	void OnGUI () {
		if (!isPortChosen) {
			for (int i = 0; i < portList.Length; i++) {
				if (GUI.Button (new Rect(40, 60 + (i * 30), 80, 20), portList[i])) {
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
					gun.transform.localRotation = direction;
					if ((int.Parse(strEul[2]) == 1) && (myResources.GotResource(gunCode.laserCost, 0.0f, 0.0f, 0.0f, 0.0f))) {
						//Gunfire
						gunCode.Fire ();
						if (!gunSound[0].isPlaying) {
							gunSound[0].Play ();

						}
					} else {
						gunSound[0].Stop();
					}
					if ((int.Parse(strEul[1]) == 1) && (Time.time > gunNextTime2) && (myResources.GotResource(0.0f, 0.0f, 0.0f, gunLobCost, 0.0f))) {
						//Gunfire 2
						//Debug.Log ("Fire");
						CmdLobBullet();
						//CmdLobTheBullet();
						gunNextTime2 = Time.time + gunInterval2;
						gunSound[1].Play();

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
		GameObject go = GameObject.Find(this.transform.parent.name);
		go.GetComponent<Resources>().UseResource(0.0f, 0.0f, 0.0f, gunLobCost, 0.0f);
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

