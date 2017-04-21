using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScrollList : MonoBehaviour {

    public List<ShopItem> itemList;
    public Transform contentPanel;
    public SimpleObjectPool itemObjectPool;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public class ShopItem {
    public Sprite icon;
    public string name;
    public float price = 1f;
}