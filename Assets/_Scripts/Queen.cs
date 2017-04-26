using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class Queen : MonoBehaviour {
    public string characterName = "Queen";

    public List<List<string>> convo = new List<List<string>>();
    public List<string> convoDay0Morning = new List<string>();
    public List<string> convoDay0Evening = new List<string>();
    public List<string> convoDay1Morning = new List<string>();
    public List<string> convoDay1Evening = new List<string>();
    public List<string> convoDay2Morning = new List<string>();
    public List<string> convoDay2Evening = new List<string>();
    public List<string> convoDay3Morning = new List<string>();
    public List<string> convoDay3Evening = new List<string>();
    public int dayIndex = 0;
    public int convoIndex = 0;

    public GameObject dialogPanel;
    public Text dialogName;
    public Text dialogConvo;

    public UIDController uidCtl;

    public GameObject night;

    public string itemNeeded = "Name";

    [Header("When Player is Near")]
    public GameObject player;

    // Use this for initialization
    void Start() {
        convo.Add(convoDay0Morning);
        convo.Add(convoDay0Evening);
        convo.Add(convoDay1Morning);
        convo.Add(convoDay1Evening);
        convo.Add(convoDay2Morning);
        convo.Add(convoDay2Evening);
        convo.Add(convoDay3Morning);
        convo.Add(convoDay3Evening);
    }

    // Update is called once per frame
    void Update() {
        if (player != null && Input.GetKeyUp(KeyCode.J)) {
            ConvoNextLine();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            if (dayIndex % 2 == 1) {
                foreach (InventoryItem iItem in uidCtl.inventory) {
                    if (iItem.itemName == "Name") {
                        uidCtl.DeleteItem(iItem);
                        break;
                    }
                }
            }
            player = collision.gameObject;
            dialogName.text = characterName;
            dialogConvo.text = convo[dayIndex][convoIndex];
            //UpdateConvoIndex();
            dialogPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            player = null;
            convoIndex = 0;
            dialogPanel.SetActive(false);
        }
    }



    private void UpdateConvoIndex() {
        if (convoIndex < convo[dayIndex].Count - 1) {
            convoIndex++;
        } else {
            convoIndex = 0;
        }
    }

    public void DayIncrementOne() {
        dayIndex++;
    }

    public void ConvoNextLine() {
        UpdateConvoIndex();
        if (convoIndex != 0) {
            dialogConvo.text = convo[dayIndex][convoIndex];
        } else if (dayIndex % 2 != 0) {
            StartCoroutine(NextDay());
        } else {
            dialogPanel.SetActive(false);
        }
    }

    IEnumerator NextDay(float time = 2) {
        dialogPanel.SetActive(false);
        night.SetActive(true);

        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1;

        player.transform.position += new Vector3(-5, 0, 0);
        player.GetComponent<PlatformerCharacter2D>().Move(1, false, false);

        DayIncrementOne();
        night.SetActive(false);
    }
}
