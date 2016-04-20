using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class targetLife : NetworkBehaviour {


	private bool alive;
	//public GameObject explosion;
	//public GameObject bigExplosion;
	public Resources myResources;
	[SyncVar] float life;

	//public AudioClip gunfireSound;
	public GameObject myself;

	void Start () {
		life = 6000.0f;
		alive = true;

		this.BroadcastMessage("Activate", SendMessageOptions.DontRequireReceiver);
	}
	

	void Update () {
		if (life <= 0f) {
			Debug.Log ("Death");
			//Die ();
		}
	}

	public void CauseDamage (Vector4 hit) {
		
		//life -= hit.w;
		//myResources.resource4 -= hit.w;
		myResources.TakeDamage(hit.w);
		Debug.Log ("Hit for " + hit.w + ".   Capacity: " + myResources.resource4);
		//Instantiate (smoke, new Vector3(hit.x, hit.y, hit.z),this.transform.rotation);
		//myResources.CmdRayHit(new Vector3(hit.x, hit.y, hit.z));


	}

	void Die () {
		if (alive) {
			//if (!GetComponent<AudioSource>().isPlaying) {
			//	if (Random.Range(0f,1.0f) < 0.5f ) {
					//Instantiate (explosion, this.transform.position, this.transform.rotation);
			//	} else {
					//Instantiate (bigExplosion, this.transform.position, this.transform.rotation);
			//	}
			//	GetComponent<AudioSource>().pitch = Random.Range (1.3f, 2.1f);
			//	GetComponent<AudioSource>().Play ();
				alive = false;
			//	GetComponent<MeshRenderer>().enabled = false;
				this.BroadcastMessage("Deactivate", SendMessageOptions.DontRequireReceiver);
			//}
		}// else if (!GetComponent<AudioSource>().isPlaying) {
			//GameObject newTarget = Instantiate (myself, new Vector3 (this.transform.position.x + Random.Range(-10.0f, 10.0f), this.transform.position.y, this.transform.position.z + Random.Range(-10.0f, 10.0f)), Quaternion.identity) as GameObject; 
			//newTarget.GetComponent<MeshRenderer>().enabled = true;
			//Destroy (this.gameObject);
		//}
	}



}
