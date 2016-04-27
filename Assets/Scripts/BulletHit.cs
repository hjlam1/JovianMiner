using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BulletHit : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log ("TriggerEntered");
		if (other.CompareTag("Bullet")) {
			//Debug.Log( "Bullet Hit");
			if (isServer) {
				this.GetComponentInParent<Resources>().HitByBullet();
			}
		}
	}
}
