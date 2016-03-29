using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class joystickTest2 : NetworkBehaviour {

	public GameObject ship;
	private float speedFactor = 2.0f;
	private float revRange = 2.0f;
	private float superChargerFactor = 1.0f;
	private float superChargerStart = 0.75f;
	private float maxSuperChargerVolume = 0.4f;
	public bool isMiningOn = false;
	public float miningStrength;
	private float baseMiningStrength = 100.0f;
	private float comEfficiency;
	private float comFactor = 0.9f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (isLocalPlayer) {
			if (Mathf.Abs (Input.GetAxis ("Drive")) > superChargerStart) {
				superChargerFactor = 1.75f;
			} else {
				superChargerFactor = 1.0f;
			}
			ship.GetComponent<CharacterController>().SimpleMove(transform.forward * Input.GetAxis ("Drive") * speedFactor * superChargerFactor);
			ship.transform.Rotate (Vector3.up * Input.GetAxis ("Steering"));

			if (Input.GetKeyUp(KeyCode.JoystickButton0)) {
				isMiningOn = !isMiningOn;
			}
			comEfficiency = 1-((Input.GetAxis ("Signal") + 1) / 2 * comFactor);
			miningStrength = baseMiningStrength * comEfficiency;
			//Debug.Log (Input.GetAxis ("Signal"));
			PlaySound ();
		}

	}

	void OnGUI () {
		//GUI.Box(new Rect(10,10,100,90), miningStrength.ToString());
	}

	void PlaySound() {
		AudioSource[] rumble = ship.GetComponents<AudioSource>();
		if ((rumble[0].isPlaying) && (Mathf.Abs (Input.GetAxis ("Drive")) > 0.05f)) {
			//Debug.Log ("Modulate Engine");
			rumble[0].pitch = 0.35f + (Mathf.Abs (Input.GetAxis ("Drive")) * revRange);
			if (Mathf.Abs (Input.GetAxis ("Drive")) > superChargerStart) {
				rumble[1].volume = maxSuperChargerVolume;
				rumble[1].pitch = -0.5f + (Mathf.Abs (Input.GetAxis ("Drive")) * 2.0f);
			} else {
				rumble[1].volume = 0.0f;
			}
		} else {
			rumble[0].pitch = 0.35f;
			rumble[1].pitch = 0.7f;
		}

		if (isMiningOn) {
			if (!rumble[4].isPlaying) {
				rumble[4].Play();
			}
		} else {
			rumble[4].Stop();
		}
	}
}
