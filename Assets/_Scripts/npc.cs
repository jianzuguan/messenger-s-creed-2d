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
    //private Item mission_require_sc;
    //private InventoryItem mission_require;
    public UIDController sc;
    //public string NeededItem;
    //public int NeededNumber;
    public List<InventoryItem> itemNeeded;
    // Index for
    // 0 Item to sell
    // 1 Item sell for (gold)
    //public List<InventoryItem> itemTrades;
    public List<InventoryItem> itemToGive;

	private GameObject item_script1;
	// Use this for initialization
	void Start () {
		current_state = 0;
		GameObject item_script = GameObject.Find ("CanvasUID");
        sc = item_script.GetComponent<UIDController>();
        //if(item_script1 = GameObject.Find (NeededItem)){Debug.Log("succ");}
        //Item mission_require_sc = item_script1.GetComponent<Item> ();
        //mission_require_sc = item_script1.GetComponent<Item> ();
        //mission_require=mission_require_sc.the_item;
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
	public void is_mission_complete(){
        //mission_comp = true ? sc.HasItem (mission_require,NeededNumber) : false;
        //mission_comp = true ? sc.DeleteItem (mission_require) : false;
        mission_comp = sc.HasItem(itemNeeded[0]);
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
			//take item from backpack
			//flush backbak
			current_state=2;
            //sc.DeleteItem (mission_require);
            sc.DeleteItem(itemNeeded[0]);
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
			is_mission_complete ();
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


    public void Trade() {
        // Give item to player
        //sc.AddItem(itemTrades[0]);
        // Take gold from player
        //sc.DeleteItem(itemTrades[1]);
        
    }
}
