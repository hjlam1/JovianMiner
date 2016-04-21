using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Resources : NetworkBehaviour {

	public GameObject smoke;
	private float resource0RegenRate;
	private float resource4RegenRate;
	//public float resource4 = 1000.0f;
	public Material myFrame;
	public Material hitMyFrame;

	private float maxResource0 = 1000.0f;
	private float maxResource4 = 1000.0f;

	[SyncVar] public float resource0 = 1000.0f;
	[SyncVar] public float resource1 = 0f;
	[SyncVar] public float resource2 = 0f;
	[SyncVar] public float resource3 = 0f;
	[SyncVar] public float resource4 = 1000.0f;
	[SyncVar] public bool normal = true;






	// Use this for initialization
	void Start () {
		resource0RegenRate = 0.5f;
		resource4RegenRate = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (resource0 > maxResource0 ) {
			resource0 = maxResource0;
		}
		if (resource0 < 0.0f ) {
			resource0 = 0.0f;
		}
		if (resource4 >= maxResource4 ) {
			resource4 = maxResource4;
			normal = true;
		} else {
			normal = false;
		}
		if (resource4 < 0.0f) {
			resource4 = 0.0f;
		}

		if (normal) {
			this.GetComponentInChildren<StaticWireframeRenderer>().WireMaterial = myFrame;
		} else {
			this.GetComponentInChildren<StaticWireframeRenderer>().WireMaterial = hitMyFrame;
		}
	}

	void FixedUpdate() {

		if (isServer) {
			if (resource0 < maxResource0) {
				resource0 += resource0RegenRate;
			}
			if (resource4 < maxResource4) {
				resource4 += resource4RegenRate;
			}
		}
	}

	public void TakeDamage (float amount) {
		if (!isServer) {
			return;
		}
		if (resource4 - amount >=0) {
			resource4 -= amount;
			//RpcDamage(amount);
		}

	}

	[ClientRpc]

	void RpcDamage (float amount) {
		Debug.Log("Took Damage:" + amount);
	}

}
