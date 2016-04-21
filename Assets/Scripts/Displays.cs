using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Displays : NetworkBehaviour
{
	// Use this for initialization

	void Start()
	{
		Debug.Log("Displays connected: " + Display.displays.Length);

		if (Display.displays.Length > 1)
			Display.displays[1].Activate();
		if (Display.displays.Length > 2)
			Display.displays[2].Activate();


	}
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey("escape"))
			Application.Quit();
		if (Input.GetKey(KeyCode.H)) {
			
		}
	}
}