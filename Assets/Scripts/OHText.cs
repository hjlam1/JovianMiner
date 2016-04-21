using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OHText : MonoBehaviour {

	public Resources OHResources;
	public string OHTxt;

	void Start () {

	}

	// Update is called once per frame
	void Update () {

		OHTxt =	  
			"       Solar: " + OHResources.resource0.ToString() + "\n"
			+ "Resource 1: " + OHResources.resource1.ToString() + "\n"
			+ "Resource 2: " + OHResources.resource2.ToString() + "\n"
			+ "Resource 3: " + OHResources.resource3.ToString() + "\n"
			+ "      Health: " + OHResources.resource4.ToString();

		this.GetComponent<Text>().text = OHTxt;


	}
}
