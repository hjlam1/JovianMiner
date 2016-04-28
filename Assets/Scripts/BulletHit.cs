using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BulletHit : NetworkBehaviour {

	private float spawnY = -0.96f; 
	public GameObject materialLocation;
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
				SpawnMaterialLoot(this.GetComponentInParent<Resources>().HitByBullet());
				//SpawnMaterialLoot();

			}
		}
			
	}


	void SpawnMaterialLoot(float resDist) {
		GameObject matLoc = (GameObject) Instantiate (materialLocation, new Vector3(this.transform.position.x, spawnY, this.transform.position.z),Quaternion.identity);
		matLoc.GetComponent<OreDeposit>().SetDepositQuantity(500.0f, resDist / 3.0f, resDist / 3.0f, resDist / 3.0f);

		Destroy (matLoc, 15.0f);
		NetworkServer.Spawn (matLoc);
		//matLoc.transform.localScale -= new Vector3(3.5f, 0.0f, 3.5f);
	}
}
