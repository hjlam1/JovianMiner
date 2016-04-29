using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class OreDeposit : NetworkBehaviour {


	private float rapidMineFactor = 2.0f;
	private float rapidMineCost = 20.0f;

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
		if (Input.GetKey(KeyCode.H)) {
			SetDepositQuantity();
		}
	}

	void OnTriggerStay(Collider other) {
		//Debug.Log ("Entered Location");
		if (other.CompareTag("Player")) {
			if (other.GetComponent <joystickTest>().isMiningOn) {
				MiningOperation(other);
				//Debug.Log ("Mining");
			}
			if ((depositsLeft > 0.0f) && (other.transform.name == "GuangHua") && (other.GetComponent<Resources>().GotResource(999.0f, 0f, 20.0f, 0f, 0f)) &&((Input.GetButtonDown("Com2G")) || (Input.GetKeyUp(KeyCode.S)))) {
				depositsLeft = 0.0f;
				other.GetComponent<Resources>().resource1 += ore1 * rapidMineFactor; 
				other.GetComponent<Resources>().resource2 += ore2 * rapidMineFactor;
				other.GetComponent<Resources>().resource3 += ore3 * rapidMineFactor;
				other.GetComponent<Resources>().UseResource(999.0f, 0f, rapidMineCost, 0f, 0f);
			}
			if ((depositsLeft > 0.0f) && (other.transform.name == "OnyxHill") && (other.GetComponent<Resources>().GotResource(999.0f, 0f, 20.0f, 0f, 0f)) && ((Input.GetButtonDown("Com2O")) || (Input.GetKeyUp(KeyCode.N)))) {
				depositsLeft = 0.0f;
				other.GetComponent<Resources>().resource1 += ore1 * rapidMineFactor; 
				other.GetComponent<Resources>().resource2 += ore2 * rapidMineFactor;
				other.GetComponent<Resources>().resource3 += ore3 * rapidMineFactor;
				other.GetComponent<Resources>().UseResource(999.0f, 0f, rapidMineCost, 0f, 0f);
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

	public void SetDepositQuantity(float dep, float o1, float o2, float o3) {
		depositsLeft = Random.Range(300.0f, dep);
		ore1 = Random.Range(1.0f, o1);
		ore2 = Random.Range(1.0f, o2);
		ore3 = Random.Range(1.0f, o3);
	}
	[Command]
	void CmdSetDepositQuantity () {
		depositsLeft = Random.Range(1000.0f, 6000.0f);
		ore1 = Random.Range(1.0f, 20.0f);
		ore2 = Random.Range(1.0f, 20.0f);
		ore3 = Random.Range(1.0f, 20.0f);

	}

}
