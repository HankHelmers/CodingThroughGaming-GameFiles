using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private LevelManager levelManager;
    public string nextLevelName;

    void Start() {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            // win the level

            // play an animation
            GetComponent<Animator>().SetTrigger("EndReached");

            // move on to the next level -> extra content transition
            levelManager.LoadNextLevel(nextLevelName);
        }
    }
}
