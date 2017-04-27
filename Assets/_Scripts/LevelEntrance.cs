using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEntrance : MonoBehaviour {

    public Camera camera;
    public GameObject player;

    [Header("Normal")]
    public GameObject farWest;
    public GameObject farEast;
    public Transform cameraPoint;
    public Transform playerPoint;

    [Header("Dwarf")]
    public int numOfNameNeeded;
    // Check book amount
    public UIDController uidCtl;
    // Check if is final day
    public IFoundFinalName finalDayCheck;

    public GameObject dwarfFarWest;
    public GameObject dwarfFarEast;
    public Transform dwarfCameraPoint;
    public Transform dwarfPlayerPoint;


    // Use this for initialization
    void Start() {
        if (camera == null) {
            camera = Camera.main;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            if (finalDayCheck.isFinalDay && uidCtl.totalNameFound >= numOfNameNeeded) {
                farWest = dwarfFarWest;
                farEast = dwarfFarEast;
                cameraPoint = dwarfCameraPoint;
                playerPoint = dwarfPlayerPoint;
            }

            camera.GetComponent<CameraFollower>().RefreshBoundary(farWest, farEast, cameraPoint);

            camera.transform.position = cameraPoint.position;
            player.GetComponent<NeverFallOff>().SetCurrentHeght(playerPoint.position.y);
            player.transform.position = playerPoint.position;

        }
    }

}
