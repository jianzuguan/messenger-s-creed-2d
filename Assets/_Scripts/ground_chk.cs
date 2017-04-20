using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_chk : MonoBehaviour {
	private player_ctrl player;
	// Use this for initialization
	void Start () {
		player = gameObject.GetComponentInParent<player_ctrl> ();
	}



	void OnTriggerEnter2D(Collider2D cl){
		if (cl.gameObject.tag == "gnd") {
			player.sc_grounded = true;
			//Debug.Log("set t");
		}
	}
	// Update is called once per frame
	void OnTriggerExit2D (Collider2D cl) {
		if (cl.gameObject.tag == "gnd") {
			player.sc_grounded = false;
			//Debug.Log("set f");
		}
	}
	void OnTriggerStay2D(Collider2D cl)
	{
		if (cl.gameObject.tag == "gnd") {
			player.sc_grounded = true;
			//Debug.Log("set t_stay");
		}
	}
}
