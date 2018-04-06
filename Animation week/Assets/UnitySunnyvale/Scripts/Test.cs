using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("Starting " + this.name);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Update");
	}

	void Awake()
	{
	}

	void FixedUpdate()
	{
	}
}
