//This Scropt for manage Collectable coin behavior
using UnityEngine;

public class Coin : MonoBehaviour
{
    AudioManager audioManager; // Audio manager reference for coin collect SFX

    private void Awake() {
        // Audio manager reference for coin collect SFX
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    //when player collided a coin this will trigger
    private void OnTriggerEnter(Collider other) {
        //Player Inventory class ref for increment score
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.CoinCollected(); //Increment score
            gameObject.SetActive(false); // Desapear the coin
            audioManager.PlaySFX(audioManager.coin); // play SFX
        }
    }
}
