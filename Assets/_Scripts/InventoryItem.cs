using UnityEngine;

[System.Serializable]
public class InventoryItem {

    public Sprite icon;
    public string itemName;
    public int itemCount;

    public InventoryItem(Sprite icon, string itemName, int itemCount = 1) {
        this.icon = icon;
        this.itemName = itemName;
        this.itemCount = itemCount;
    }
}