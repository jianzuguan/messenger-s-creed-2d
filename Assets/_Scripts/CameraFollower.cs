using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

    public GameObject player;
    public bool canGoBack;

    public GameObject farWest;
    public GameObject farEast;

    public float xMin;
    public float xMax;

    Vector3 offset;
    float x, y, z;

    Camera cam;
    public float camHeight;
    public float camWidth;

    void Start() {
        if (player == null)
            player = GameObject.FindWithTag("Player");
        //offset = transform.position - player.transform.position;

        cam = Camera.main;
        cam.aspect = 16f / 9f;

        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        if (farWest != null) {
            xMin = farWest.transform.position.x + camWidth / 2 + 0.5f;
        }
        if (farEast != null) {
            xMax = farEast.transform.position.x - camWidth / 2 - 0.5f;
        }

        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    void LateUpdate() {
        offset = transform.position - player.transform.position;
        if (transform.position.x < xMax && offset.x < -5) {
            // Move right
            x = player.transform.position.x - 5;
            transform.position = new Vector3(x, y, z);
        } else if (canGoBack && transform.position.x > xMin && offset.x > 5) {
            // Move left
            x = player.transform.position.x + 5;
            transform.position = new Vector3(x, y, z);
        }
    }

    public void RefreshBoundary(GameObject farWest, GameObject farEast, Transform cameraPoint) {
        x = cameraPoint.position.x;
        y = cameraPoint.position.y;
        z = cameraPoint.position.z;

        this.farWest = farWest;
        this.farEast = farEast;

        if (farWest != null) {
            xMin = farWest.transform.position.x + camWidth / 2 + 0.5f;
        }
        if (farEast != null) {
            xMax = farEast.transform.position.x - camWidth / 2 - 0.5f;
        }
        
    }
}
