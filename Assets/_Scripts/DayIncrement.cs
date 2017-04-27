using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayIncrement : MonoBehaviour {

    public Queen queen;

    [Header("Debug")]
    public int day = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            queen.DayIncrementOne();
            day++;
            if (day > 2) {
                collision.gameObject.GetComponent<IFoundFinalName>().isFinalDay = true;
            }
        }
    }

}
