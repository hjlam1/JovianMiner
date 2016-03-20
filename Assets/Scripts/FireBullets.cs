using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class FireBullets : NetworkBehaviour {

	public GameObject bullet_prefab;
	//private float speed = 15000.0f;
	public GameObject gun;

	//[SyncVar]
	//public GameObject theBullet;

	void Start () {
	
	}
	
	public void LobBullet () {
		//theBullet = (GameObject) Instantiate (bullet_prefab, new Vector3(gun.transform.position.x, gun.transform.position.y, gun.transform.position.z), gun.transform.rotation);
		//theBullet.GetComponent<Rigidbody>().AddForce (-gun.transform.forward * speed);
		//NetworkServer.Spawn(theBullet);

	}

	[Command]

	public void CmdLobBullet() {
		//GameObject obj = (GameObject) Instantiate (bullet_prefab, new Vector3(gun.transform.position.x, gun.transform.position.y, gun.transform.position.z), gun.transform.rotation);
		//BulletSpecs bullet = obj.GetComponent<BulletSpecs>();
		//bullet.firedFrom = -gun.transform.forward * speed;
		//Destroy (obj, 5.0f);
		//Debug.Log ("CmdLobBullet called");
		//NetworkServer.Spawn (obj);
	}
}
