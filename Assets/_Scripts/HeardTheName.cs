using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class HeardTheName : MonoBehaviour {

    public GameObject canvasConvo;
    public Animation cameraMove;

    [Header("Debug")]
    public GameObject player;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (player != null) {
            if (GetComponent<npc>().indx == GetComponent<npc>().convs1.Count) {
                player.GetComponent<IFoundFinalName>().hasFinalName = true;
                player.GetComponent<Platformer2DUserControl>().enabled = true;
                gameObject.SetActive(false);
                canvasConvo.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            player = collision.gameObject;
            //playerSpeed = collision.gameObject.GetComponent<PlatformerCharacter2D>().m_MaxSpeed;
            //collision.gameObject.GetComponent<PlatformerCharacter2D>().m_MaxSpeed = 0f;
            //collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.gameObject.GetComponent<PlatformerCharacter2D>().Move(0, false, false);
            collision.gameObject.GetComponent<Platformer2DUserControl>().enabled = false;
            cameraMove.Play();
        }
    }

}
