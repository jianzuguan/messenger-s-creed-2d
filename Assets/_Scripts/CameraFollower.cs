using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

    public GameObject player;
    public bool canGoBack;
    
    public GameObject farEast;

    float xMin;
    float xMax = float.MaxValue;

    Vector3 offset;
    float x, y, z;

    void Start() {
        if (player == null)
            player = GameObject.FindWithTag("Player");
        //offset = transform.position - player.transform.position;

        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        Camera.main.aspect = 16f / 9f;

        xMin = transform.position.x;
        if (farEast != null)
            xMax = farEast.transform.position.x - camWidth / 2 - 0.5f;

        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    void LateUpdate() {
        offset = transform.position - player.transform.position;
        if (transform.position.x < xMax && offset.x < -5) {
            x = player.transform.position.x - 5;
            transform.position = new Vector3(x, y, z);
        } else if (canGoBack && transform.position.x > xMin && offset.x > 5) {
            x = player.transform.position.x + 5;
            transform.position = new Vector3(x, y, z);
        }
    }
}
