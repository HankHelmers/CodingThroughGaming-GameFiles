using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : Trap
{

    private bool movingLeft; 

    public float leftEdge;
    public float rightEdge; 
    public float speed; 

    private void Update() {
        float xPosition = transform.position.x;
        
        // move from left to right 
        if(movingLeft) {
            if(xPosition > leftEdge) {
                //reached the left edge
                transform.position = new Vector3(xPosition - speed * Time.deltaTime, transform.position.y, 0);
            } else { //swutch from moving left to right
                movingLeft = false; 
            }
        } else { //moving right
            if(xPosition < rightEdge) {
                //reached the right edge
                transform.position = new Vector3(xPosition + speed * Time.deltaTime, transform.position.y, 0);
            } else { //switch from moving to the right to the left
                movingLeft = true;
            }
        }


    }
}
