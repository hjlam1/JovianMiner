using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class OreDeposit : NetworkBehaviour {

	[SyncVar] public float depositsLeft;
	[SyncVar] public float ore1;
	[SyncVar] public float ore2;
	[SyncVar] public float ore3;


	// Use this for initialization
	void Start () {
		SetDepositQuantity();
	
	}
	
	// Update is called once per frame
	void Update () {
		//this.GetComponent<ParticleSystem>().startSize = 0.005f * depositsLeft;
		this.transform.localScale = new Vector3 (this.transform.localScale.x, depositsLeft / 1000.0f , this.transform.localScale.z);
	}

	void OnTriggerStay(Collider other) {
		//Debug.Log ("Entered Location");
		if (other.CompareTag("Player")) {
			if (other.GetComponent <joystickTest>().isMiningOn) {
				MiningOperation(other);
				//Debug.Log ("Mining");
			}
		}
	}

	void MiningOperation(Collider other) {
		if (depositsLeft > 0f) {
			//Debug.Log ("Deposits Remaining: " + );
			other.GetComponent<Resources>().resource1 += ore1 * Time.deltaTime; 
			other.GetComponent<Resources>().resource2 += ore2 * Time.deltaTime;
			other.GetComponent<Resources>().resource3 += ore3 * Time.deltaTime;
			depositsLeft -= other.GetComponent<joystickTest>().miningStrength * Time.deltaTime;
		} 
	}

	void SetDepositQuantity () {
		depositsLeft = Random.Range(1000.0f, 6000.0f);
		ore1 = Random.Range(1.0f, 20.0f);
		ore2 = Random.Range(1.0f, 20.0f);
		ore3 = Random.Range(1.0f, 20.0f);

	}

}
