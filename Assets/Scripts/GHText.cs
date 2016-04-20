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
		
		GHTxt = GHResources.resource4.ToString() + "\n" +GHResources.resource1.ToString();

		this.GetComponent<Text>().text = GHTxt;


	}
}
