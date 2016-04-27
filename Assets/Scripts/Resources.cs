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

	public void UseResource (float amount0, float amount1, float amount2, float amount3, float amount4) {
		if (!isServer) {
			return;
		}
		//Debug.Log(amount0.ToString() + " " + amount1.ToString());
		if (resource0 - amount0 >=0) {
			resource0 -= amount0;

		}
		if (resource1 - amount1 >=0) {
			resource1 -= amount1;

		}
		if (resource2 - amount2 >=0) {
			resource2 -= amount2;

		}
		if (resource3 - amount3 >=0) {
			resource3 -= amount3;

		}
		if (resource4 - amount4 >=0) {
			resource4 -= amount4;

		}


	}

	public bool GotResource (float amount0, float amount1, float amount2, float amount3, float amount4) {
		bool b0 = false;
		bool b1 = false;
		bool b2 = false;
		bool b3 = false;
		bool b4 = false;
		if (resource0 - amount0 >=0) {
			b0 = true;
		}
		if (resource1 - amount1 >=0) {
			resource1 -= amount1;
			b1 = true;
		}
		if (resource2 - amount2 >=0) {
			resource2 -= amount2;
			b2 = true;
		}
		if (resource3 - amount3 >=0) {
			resource3 -= amount3;
			b3 = true;
		}
		if (resource4 - amount4 >=0) {
			resource4 -= amount4;
			b4 = true;
		}
		if (b0 && b1 && b2 && b3 && b4) {
			return true;
		} else return false;
	}

	public void HitByBullet () {
		float lossPercentage = 0.5f;
		float lostR1 = 0;
		float lostR2 = 0;
		float lostR3 = 0;

		if (!isServer) {
			return;
		}
		if (resource1 > 0) {
			lostR1 = Random.Range(0, resource1 * lossPercentage);
			resource1 -= lostR1;
		}
		if (resource2 > 0) {
			lostR2 = Random.Range(0, resource2 * lossPercentage);
			resource2 -= lostR2;
		}
		if (resource3 > 0) {
			lostR3 = Random.Range(0, resource3 * lossPercentage);
			resource3 -= lostR3;
		}

		if (lostR1+lostR2+lostR3 > 0) {
			Debug.Log (this.transform.name + " loses some resources");
		}
	}

	[ClientRpc]

	void RpcDamage (float amount) {
		Debug.Log("Took Damage:" + amount);
	}

}
