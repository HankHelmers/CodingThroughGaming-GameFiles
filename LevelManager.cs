using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1;

    private PlayerMovement playerController;

    void Start() {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void LoadNextLevel(string sceneName) {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName) {
        // Play Animation
        Debug.Log("Aniamtion Starts");
        transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load Scene
        SceneManager.LoadScene(sceneName);
    }
}
