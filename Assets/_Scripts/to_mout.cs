using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class to_mout : MonoBehaviour {
	public GameObject portal;
	public string scene_name;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D pl){
		if (pl.gameObject.tag=="Player")
		{
			//TODO change scene
			Debug.Log("changed");
		}
			
	}
}
