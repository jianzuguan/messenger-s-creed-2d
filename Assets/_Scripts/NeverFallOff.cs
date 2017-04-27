using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverFallOff : MonoBehaviour {

    public float currentHeight;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < currentHeight-0.5) {
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
        }
	}

    public void SetCurrentHeght(float height) {
        currentHeight = height;
    } 
}
