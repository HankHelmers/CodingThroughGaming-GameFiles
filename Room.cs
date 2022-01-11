using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    // when the player is in this trigger area we want to tell the camera that
    // the camera will then move to that rooms position. 

    public CameraController camera;

    void Start() {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player" && camera != null) {

            camera.MoveToNewRoom(transform); 

        }
    }
}
