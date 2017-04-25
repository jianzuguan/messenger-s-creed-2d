using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDController : MonoBehaviour {

    public List<InventoryItem> inventory = new List<InventoryItem>();
    public GameObject inventoryContainer;
    public GameObject itemUIPrefab;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RefreshUID();
	}

    public void RefreshUID() {
        // Clean inventory UI
        for (int i = inventoryContainer.transform.childCount; i > 0; i--) {
            Destroy(inventoryContainer.transform.GetChild(i - 1).gameObject);
        }

        if (inventory.Count == 0) {
            return;
        }

        float y = 0;
        foreach (InventoryItem iItem in inventory) {
            GameObject itemUI = Instantiate(itemUIPrefab, inventoryContainer.transform, false) as GameObject;

            itemUI.GetComponent<InventoryItemUI>().Setup(iItem.icon, iItem.itemName, iItem.itemCount, y);
            y -= 50;
        }
        
    }

    public void AddItem(InventoryItem newItem) {
        // Add one to exsiting item
        foreach (InventoryItem iItem in inventory) {
            if (iItem.itemName == newItem.itemName) {
                iItem.itemCount+=newItem.itemCount;
                RefreshUID();
                return;
            }
        }

        // Create new Item if not found
        inventory.Add(newItem);
        RefreshUID();
    }
	public bool HasItem(InventoryItem targetItem,int ItemNumber){
		foreach (InventoryItem iItem in inventory) {
			if (iItem.itemName == targetItem.itemName && iItem.itemCount >= ItemNumber) {
				return true;}
		}
		return false;
	}
    public bool DeleteItem(InventoryItem targetItem) {
        for (int i = 0; i < inventory.Count; i++) {
            InventoryItem iItem = inventory[i];
            if (iItem.itemName == targetItem.itemName) {
                if (iItem.itemCount - targetItem.itemCount > 0) {
                    iItem.itemCount -= targetItem.itemCount;
                    RefreshUID();
                    return true;
                } else if (iItem.itemCount - targetItem.itemCount == 0) {
                    inventory.RemoveAt(i);
                    RefreshUID();
                    return true;
                } else {
                    // count > itemCount
                    return false;
                }
            }
        }
        return false;
    }
}

