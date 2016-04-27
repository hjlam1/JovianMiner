using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class rayShoot : NetworkBehaviour {

	public Transform explosion;
	public float beamDamage;
	public float beamDistance;
	private Vector4 theHit;
	public float laserCost = 10.0f;

	void Start () {
		beamDamage = 10.0f;
		beamDistance = 100.0f;
	}
	
	// Update is called once per frame
	public void Fire () {
		RaycastHit hit;
		CmdUseResourceZero(this.transform.parent.name);
		if (Physics.Raycast (new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.5f) , this.transform.forward, out hit, beamDistance)) {
			//this.GetComponent<LineRenderer>().SetPosition(0,this.transform.position);
			//this.GetComponent<LineRenderer>().SetPosition(1, hit.point);
			//Debug.Log(hit.point);
			theHit = new Vector4(hit.point.x, hit.point.y, hit.point.z, beamDamage);
			//hit.transform.SendMessage ("CauseDamage", theHit, SendMessageOptions.DontRequireReceiver);
			string target = hit.transform.name;
			//Debug.Log (target);
			CmdTellServerSomeoneDamaged( theHit, target);
		}
	}

	[Command]

	void CmdTellServerSomeoneDamaged( Vector4 hit, string target) {
		GameObject go = GameObject.Find(target);
		go.GetComponent<targetLife>().CauseDamage (hit);
	}

	[Command]
	void CmdUseResourceZero(string shooter) {
		
		GameObject go = GameObject.Find(shooter);
		//Debug.Log(shooter);
		go.GetComponent<Resources>().UseResource(laserCost, 0.0f, 0.0f, 0.0f, 0.0f);

	}

}
