using UnityEngine;
using System.Collections;

public class targetLife : MonoBehaviour {

	private float life;
	private bool alive;
	//public GameObject explosion;
	//public GameObject bigExplosion;
	//public GameObject smoke;

	public AudioClip gunfireSound;
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

	void CauseDamage (float damage) {
		Debug.Log ("Damage");
		life -= damage;
		//Instantiate (smoke, this.transform.position,this.transform.rotation);


	}

	void Die () {
		if (alive) {
			if (!GetComponent<AudioSource>().isPlaying) {
				if (Random.Range(0f,1.0f) < 0.5f ) {
					//Instantiate (explosion, this.transform.position, this.transform.rotation);
				} else {
					//Instantiate (bigExplosion, this.transform.position, this.transform.rotation);
				}
				GetComponent<AudioSource>().pitch = Random.Range (1.3f, 2.1f);
				GetComponent<AudioSource>().Play ();
				alive = false;
				GetComponent<MeshRenderer>().enabled = false;
				this.BroadcastMessage("Deactivate", SendMessageOptions.DontRequireReceiver);
			}
		} else if (!GetComponent<AudioSource>().isPlaying) {
			//GameObject newTarget = Instantiate (myself, new Vector3 (this.transform.position.x + Random.Range(-10.0f, 10.0f), this.transform.position.y, this.transform.position.z + Random.Range(-10.0f, 10.0f)), Quaternion.identity) as GameObject; 
			//newTarget.GetComponent<MeshRenderer>().enabled = true;
			//Destroy (this.gameObject);
		}
	}
}
