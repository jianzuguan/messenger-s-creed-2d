using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEntrance : MonoBehaviour {
    
    public Camera camera;
    public GameObject player;
    public GameObject cover;
    public GameObject farWest;
    public GameObject farEast;
    public Transform cameraPoint;
    public Transform playerPoint;

    // Use this for initialization
    void Start() {
        if (camera == null) {
            camera = Camera.main;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            camera.GetComponent<CameraFollower>().RefreshBoundary(farWest, farEast, cameraPoint);

            camera.transform.position = cameraPoint.position;
            player.transform.position = playerPoint.position;

        }
    }

}
