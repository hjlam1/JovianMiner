using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class rayShoot : NetworkBehaviour {

	public Transform explosion;
	public float beamDamage;
	public float beamDistance;
	private Vector4 theHit;

	void Start () {
		beamDamage = 100.0f;
		beamDistance = 100.0f;
	}
	
	// Update is called once per frame
	public void Fire () {
		RaycastHit hit;

		if (Physics.Raycast (this.transform.position, this.transform.forward, out hit, beamDistance)) {
			//this.GetComponent<LineRenderer>().SetPosition(0,this.transform.position);
			//this.GetComponent<LineRenderer>().SetPosition(1, hit.point);
			//Debug.Log(hit.point);
			theHit = new Vector4(hit.point.x, hit.point.y, hit.point.z, beamDamage);
			hit.transform.SendMessage ("CauseDamage", theHit, SendMessageOptions.DontRequireReceiver);


		}
	}


}
