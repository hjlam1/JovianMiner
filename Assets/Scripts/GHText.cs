using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GHText : MonoBehaviour {

	// Use this for initialization
	public Resources GHResources;
	public string GHTxt;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		GHTxt =	  
			  "       Solar: " + GHResources.resource0.ToString() + "\n"
			+ "Resource 1: " + GHResources.resource1.ToString() + "\n"
			+ "Resource 2: " + GHResources.resource2.ToString() + "\n"
			+ "Resource 3: " + GHResources.resource3.ToString() + "\n"
			+ "      Health: " + GHResources.resource4.ToString();

		this.GetComponent<Text>().text = GHTxt;


	}
}
