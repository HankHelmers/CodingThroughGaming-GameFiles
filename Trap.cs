using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // SPIKE TRAP - > inheritance might be a little much for right now
    // what  information do we need about the trap
    public int damage; 
    public float blockTime;

    private BoxCollider2D boxCollider; // Blocking the player from taking continual damage collider
    private CircleCollider2D triggerCollider; // Triggering the damage

    void Start() {

        boxCollider = GetComponent<BoxCollider2D>();
        triggerCollider = GetComponent<CircleCollider2D>();

    }

    void OnTriggerEnter2D(Collider2D collision) { // When the player enters the circle collider
        if(collision.tag == "Player") {

            collision.GetComponent<PlayerMovement>().DoDamage(damage);

            StartCoroutine(PushPlayer());
        }
    }

    IEnumerator PushPlayer() {
        boxCollider.enabled = true;
        triggerCollider.enabled = false; //turn off the damage collider

        yield return new WaitForSeconds(blockTime);

        boxCollider.enabled = false;
        triggerCollider.enabled = true;
    }
}
