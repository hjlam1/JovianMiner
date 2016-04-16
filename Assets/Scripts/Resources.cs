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
		if (resource0 > 1000.0f ) {
			resource0  = 1000.0f;
		}
		if (resource0 < 0.0f ) {
			resource0  = 0.0f;
		}
		if (resource4 >= 1000.0f ) {
			resource4  = 1000.0f;
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
			resource0 += resource0RegenRate;
			resource4 += resource4RegenRate;
		}
	}


}
