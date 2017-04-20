using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mout_cam : MonoBehaviour {
	public GameObject pl;
	public Transform tr;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		tr= pl.GetComponent<Transform> ();
		transform.position= new Vector3(tr.position.x,pos.y,pos.z);
	}
}
