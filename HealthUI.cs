using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private PlayerMovement playerController;

    public int previousPlayerHealth; // when the player's health changes
    public int currentPlayerHealth;
    public int maxPlayerHealth; 

    // UI 
    public Transform canvas;

    public Image fullHeartGameObject;

    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite; 

    public float spaceBtwHearts;

    public Image[] heartSprites; 

    void Start() {
        // get access to player health & current health
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        RetrieveHealthInfo();

        // array part
        heartSprites = new Image[maxPlayerHealth];

        SetupHealthUI();
    }

    void Update() {
        UpdateHealthUI();
    }

    private void RetrieveHealthInfo() {
        previousPlayerHealth = currentPlayerHealth;

        currentPlayerHealth = playerController.currentHealth;
        maxPlayerHealth = playerController.maxHealth;
    }

    private void SetupHealthUI() {
        // create sprites in loop at heart spawn at position with 

        spaceBtwHearts += fullHeartGameObject.rectTransform.rect.width;
        // UPDATE TO USE PARENT INFO SO WE CAN USE FULL HEART SPRITE
        Vector3 fullHeartAnchoredPosition = fullHeartGameObject.rectTransform.anchoredPosition;
        
        for (int i = 0; i < maxPlayerHealth; i++)
        {
            Image heartImage = Instantiate(fullHeartGameObject, transform);
            heartImage.rectTransform.anchoredPosition = new Vector3(fullHeartAnchoredPosition.x + (spaceBtwHearts * i), fullHeartAnchoredPosition.y, 0);
            
            heartSprites.SetValue(heartImage, i);
        }
    }

    private void UpdateHealthUI() {

        RetrieveHealthInfo();

        // if the player's current health changes & make it to a empty heart
        if(previousPlayerHealth != currentPlayerHealth) {
           // Debug.Log("---------------------");
           // Debug.Log("Player Health Changed");
                // current health
                for(int i = 0; i < currentPlayerHealth; i++) {
                  //  Debug.Log("Full Hearts");
                    heartSprites[i].GetComponent<Image>().sprite = fullHeartSprite;
                }

                // current empty
                for (int i = currentPlayerHealth; i < maxPlayerHealth; i++)
                {   
                  //  Debug.Log("Empty Hearts: " + i);
                    heartSprites[i].GetComponent<Image>().sprite = emptyHeartSprite;
                }
            
        }
    }
}
