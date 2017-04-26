using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	//public Sprite icon;
	//public string item_name;
	//public int numb
	private UIDController sc;
	public InventoryItem the_item;
	// Use this for initialization
	void Start () {
		GameObject item_script = GameObject.Find ("CanvasUID");
		sc = item_script.GetComponent<UIDController> ();
	//	the_item.icon = icon;
	//	the_item.itemName = item_name;
	//	the_item.itemCount = number;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter2D(Collider2D cl){
		if (cl.gameObject.tag == "Player") {
			sc.AddItem (the_item);
			Destroy (gameObject);
		}
	}
}
