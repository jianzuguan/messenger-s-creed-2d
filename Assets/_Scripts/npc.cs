using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc : MonoBehaviour {
	public string npc_name;
	public List<string> convs;
	public List<string> convs1;
	public List<string> convs2;
	private int indx;
	public Text txt;
	public Text name_txt;
	public GameObject panel;
	public bool iSActivated;
	public int current_state;
	public bool mission_comp;
	// Use this for initialization
	void Start () {
		current_state = 0;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.P) && panel.activeSelf && iSActivated) {
			if (mission_comp&&current_state!=2) {
				current_state = 1;
			}
			npc_next_dia (current_state);
		}

	}
	private void npc_next_dia(int cur_state){
		switch (cur_state) {
		case 0:
			npc_next_dia0 ();
			break;
		case 1:
			npc_next_dia1 ();
			break;
		case 2:
			npc_next_dia2 ();
			break;
		}
	}

	private void npc_next_dia0(){

		if (indx <= convs.Count-1) {
			txt.text = convs [indx];
			name_txt.text = npc_name;
			indx++;

		} else {

			throw_panel();
		}


	}
	private void npc_next_dia1(){

		if (indx <= convs1.Count-1) {
			txt.text = convs1 [indx];
			name_txt.text = npc_name;
			indx++;
		} else {
			current_state=2;
			throw_panel();
		}
	
	}
	private void npc_next_dia2(){
		if (indx <= convs2.Count-1) {
			txt.text = convs2 [indx];
			name_txt.text = npc_name;
			indx++;
		} else {
			throw_panel();
		}

	}
	public void OnTriggerEnter2D(Collider2D cl){
		if (cl.gameObject.tag == "Player")
		{
			iSActivated = true;

			panel.SetActive (true);
			indx = 0;
			if (mission_comp&&current_state!=2) {
				current_state = 1;
			}
			npc_next_dia (current_state);
		}
	}
	public void OnTriggerExit2D(Collider2D cl){
		if (cl.gameObject.tag == "Player") {
			throw_panel();
		}
	}
	public void throw_panel(){
		panel.SetActive (false);
		indx = 0;
		iSActivated = false;
	}

}
