using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class OreDeposit : NetworkBehaviour {

	private float depositsLeft;

	// Use this for initialization
	void Start () {
		depositsLeft = Random.Range(1000.0f, 4000.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<ParticleSystem>().startSize = 0.005f * depositsLeft;
	}

	void OnTriggerStay(Collider other) {
		//Debug.Log ("Entered Location");
		if (other.CompareTag("Player")) {
			if (other.GetComponent <joystickTest>().isMiningOn) {
				MiningOperation(other);
				Debug.Log ("Mining");
			}
		}
	}

	void MiningOperation(Collider other) {
		if (depositsLeft > 0f) {
			Debug.Log (depositsLeft);
			depositsLeft -= other.GetComponent<joystickTest>().miningStrength * Time.deltaTime;
		} 
	}

}
