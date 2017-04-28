using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class Queen : MonoBehaviour {
    public string characterName = "Queen";
    public Image panel_sprite;
    public Sprite npc_sprite;
    public int dayIndex = 0;
    public int convoIndex = 0;
    public List<List<string>> convo = new List<List<string>>();
    public List<string> convoDay0Morning = new List<string>();
    public List<string> convoDay0Evening = new List<string>();
    public List<string> convoDay1Morning = new List<string>();
    public List<string> convoDay1Evening = new List<string>();
    public List<string> convoDay2Morning = new List<string>();
    //public List<string> convoDay2Evening = new List<string>();
    //public List<string> convoDay3Morning = new List<string>();
    //public List<string> convoDay3Evening = new List<string>();
    public List<string> convoGrantDeath = new List<string>();
    public List<string> convoGrantWealth = new List<string>();


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
        //convo.Add(convoDay2Evening);
        //convo.Add(convoDay3Morning);
        //convo.Add(convoDay3Evening);
        convo.Add(convoGrantDeath);
        convo.Add(convoGrantWealth);
    }

    // Update is called once per frame
    void Update() {
        if (player != null && Input.GetKeyUp(KeyCode.J) && dialogPanel.activeSelf) {
            NextConvoLine();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        panel_sprite.sprite = npc_sprite;
        if (collision.gameObject.tag == "Player") {
            player = collision.gameObject;

            if (dayIndex >= convo.Count - 2) {
                return;
            }

            //            if (dayIndex % 2 == 1) {
            foreach (InventoryItem iItem in uidCtl.inventory) {
                if (iItem.itemName == "Name") {
                    uidCtl.DeleteItem(iItem);
                    break;
                }
            }
            //          }
            dialogName.text = characterName;
            dialogConvo.text = convo[dayIndex][convoIndex];
            //NextConvoIndex();
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

    public void NextConvoLine() {
        NextConvoIndex();
        if (convoIndex != 0) {
            dialogConvo.text = convo[dayIndex][convoIndex];
        } else if (dayIndex >= convo.Count - 2) {
            // Ending with queen
            if (dayIndex == convo.Count - 1) {
                // Good end
                Debug.Log("Good End");
                SceneManager.LoadScene("_Scenes/2Goodend");
            } else {
                // Bad end
                Debug.Log("Bad End");
                SceneManager.LoadScene("_Scenes/3Badend");
            }
        } else if (dayIndex < convo.Count - 2 && dayIndex % 2 != 0) {
            StartCoroutine(NextDay());
        } else {
            dialogPanel.SetActive(false);
        }
    }

    private void NextConvoIndex() {
        if (convoIndex < convo[dayIndex].Count - 1) {
            convoIndex++;
        } else {
            convoIndex = 0;
        }
    }

    IEnumerator NextDay(float time = 2) {
        dialogPanel.SetActive(false);
        night.SetActive(true);

        GameObject playerGB = player;
        playerGB.transform.position = new Vector3(5, 1, 0);
        playerGB.GetComponent<PlatformerCharacter2D>().Move(1, false, false);

        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1;


        DayIncrementOne();
        night.SetActive(false);
    }

    public void DayIncrementOne() {
        if (dayIndex < 4) {
            dayIndex++;
        }
    }

    // Heard story of dwarf dancing and singing
    public void HeardFinalName(bool heard) {
        if (heard) {
            dayIndex = convo.Count - 1;
        } else {
            dayIndex = convo.Count - 2;
        }

        dialogName.text = characterName;
        dialogConvo.text = convo[dayIndex][convoIndex];
        dialogPanel.SetActive(true);
    }

}
