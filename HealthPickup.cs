using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healingAmount; 

    void OnTriggerEnter2D(Collider2D collider2D) {
        //if player 
        if(collider2D.tag == "Player") {
            collider2D.GetComponent<PlayerMovement>().Heal(healingAmount);
            Debug.Log("Picked up!");

            GetComponent<Animator>().SetTrigger("Collected");

            StartCoroutine(DestroyFruit());

            //animation w/ coroutine & delete
        }
    }

    IEnumerator DestroyFruit() {
        GetComponent<Collider2D>().enabled = false; // so that fruits cant be pick up twice

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
