using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedMoreNames : MonoBehaviour {
    public int amountOfNameNeeded = 1;

    public UIDController uidCtl;

    [Header("Dialog display")]
    public GameObject dialog;
    public Image speakerIconContainer;
    public Text speakerNameContainer;
    public Text speechContainer;

    [Header("Dialog contents")]
    public Sprite speakerIcon;
    public string speakerName;
    public string speech;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            foreach (InventoryItem iItem in uidCtl.inventory) {
                if (iItem.itemName == "Name" && iItem.itemCount >= amountOfNameNeeded) {
                    gameObject.SetActive(false);
                } else {
                    speakerIconContainer.sprite = speakerIcon;
                    speakerNameContainer.text = speakerName;
                    speechContainer.text = speech;
                    dialog.SetActive(true);
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            dialog.SetActive(false);
        }
    }
}
