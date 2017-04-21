using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_ctrl : MonoBehaviour {
    public float maxspeed = 3f;
    public float speed = 300f;
    //public float jmpforce = 3000f;
    public bool sc_grounded = true;
    private Rigidbody2D rb;
    private Animator am;

    // Use this for initialization
    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        am = gameObject.GetComponent<Animator>();
    }
    void Update() {
        am.SetBool("grounded", sc_grounded);
        am.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (Input.GetAxis("Horizontal") < -0.1f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > 0.1f) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetButtonDown("Jump") && sc_grounded) {
            //rb.AddForce (Vector2.up * jmpforce);
            rb.velocity = new Vector2(rb.velocity.x, 8f);
            //Debug.Log("JJJ");
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            am.SetBool("attck", true);
            //am.SetBool ("attck", false);
        }
        if (Input.GetKeyUp(KeyCode.J)) {
            //am.SetBool ("attck", true);
            am.SetBool("attck", false);
        }
    }
    // Update is called once per frame
    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * speed * h);
        if (rb.velocity.x > maxspeed) {
            rb.velocity = new Vector2(maxspeed, rb.velocity.y);

        }
        if (rb.velocity.x < -maxspeed) {
            rb.velocity = new Vector2(-maxspeed, rb.velocity.y);

        }
    }
}
