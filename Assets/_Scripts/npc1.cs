﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc1 : MonoBehaviour {
	public string npc_name;
	public List<string> convs;
	public int indx;
	public Text txt;
	public Text name_txt;
	private GameObject panel;
	// Use this for initialization
	void Start () {
		//txt = GameObject.FindGameObjectWithTag ("conv_holder").guiText;
		//name_txt = GameObject.FindGameObjectWithTag ("npc_name").guiText;
		indx=0;
		panel = GameObject.FindGameObjectWithTag ("panel3");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.P)&& panel.activeSelf) {
			npc_next_dia ();
		}
		if (indx > convs.Count - 1) {
			panel.SetActive (false);
			indx = 0;
		
		}
	}


	private void npc_next_dia(){
		//indx++;
		Debug.Log ("next_dia");
		Debug.Log (convs[indx]);
		if (indx <= convs.Count-1) {
			txt.text = convs [indx];
			name_txt.text = npc_name;
			indx++;
			//Debug.Log (convs.Count);
		} else {
			//Debug.Log("set done");
			throw_panel();
		}
		//indx++;

	}
	public void OnTriggerEnter2D(Collider2D cl){
		if (cl.gameObject.tag=="Player")
		//throw_panel ();
		panel.SetActive (true);
		indx = 0;
		txt.text = convs [indx];
		name_txt.text = npc_name;
	}

	public void throw_panel(){
		panel.SetActive (false);
		indx = 0;
		//Debug.Log("set done");
		//name_txt.text = npc_name;
		//txt.text = convs [indx];
		//indx++;
	}
}
