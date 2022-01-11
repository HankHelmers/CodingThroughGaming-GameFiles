using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float timeToMove;

    private Vector3 currentPosition;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosition.x, currentPosition.y, -10), ref velocity, timeToMove);
    }


    public void MoveToNewRoom(Transform roomToMoveTo)
    {
        currentPosition = roomToMoveTo.position;
    }
}
