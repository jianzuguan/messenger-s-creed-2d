using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour {

    public Image icon;
    public Text itemName;
    public Text itemCount;

    public void Setup(Sprite icon, string itemName, int itemCount, float y) {
        this.icon.sprite = icon;
        this.itemName.text = itemName;
        this.itemCount.text = "X " + itemCount;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, y);
    }
}
