using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IFoundFinalName : MonoBehaviour {

    public string characterName = "Messenger";

    public GameObject dialogPanel;
    public Text dialogName;
    public Text dialogConvo;

    public List<string> convo = new List<string>();
    public int convoIndex = 0;

    public bool isFinalDay = false;
    public bool hasFinalName = false;

    [Header("Debug")]
    public GameObject queen;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (queen != null && hasFinalName && Input.GetKeyUp(KeyCode.J)) {
            NextConvoLine();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Queen" && isFinalDay) {
            queen = collision.gameObject;
            Debug.Log("trigger");
            if (hasFinalName) {
                dialogName.text = characterName;
                dialogConvo.text = convo[convoIndex];
                dialogPanel.SetActive(true);
            } else {
                queen.GetComponent<Queen>().HeardFinalName(hasFinalName);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Queen" && isFinalDay) {
            queen = null;
            convoIndex = 0;
            dialogPanel.SetActive(false);
        }
    }

    private void NextConvoIndex() {
        if (convoIndex < convo.Count - 1) {
            convoIndex++;
        } else {
            convoIndex = 0;
        }
    }

    public void NextConvoLine() {
        NextConvoIndex();
        if (convoIndex != 0) {
            dialogConvo.text = convo[convoIndex];
        } else {
            dialogPanel.SetActive(false);

            if (queen != null) {
                queen.GetComponent<Queen>().HeardFinalName(hasFinalName);
            }
        }
    }

}
