using UnityEngine;
using System.Collections;

public class rayShoot : MonoBehaviour {

	public Transform explosion;
	public float beamDamage;
	public float beamDistance;

	void Start () {
		beamDamage = 100.0f;
	}
	
	// Update is called once per frame
	public void Fire () {
		RaycastHit hit;

		if (Physics.Raycast (this.transform.position, this.transform.forward, out hit, beamDistance)) {
			//this.GetComponent<LineRenderer>().SetPosition(0,this.transform.position);
			//this.GetComponent<LineRenderer>().SetPosition(1, hit.point);			
			hit.transform.SendMessage ("CauseDamage", beamDamage, SendMessageOptions.DontRequireReceiver);
		}
	}
}
