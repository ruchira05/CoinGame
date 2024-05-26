// This script keep track player coin coint and whether all coins are collected
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    // public variables
    // Use Unity events to execute onCoinCollected and onAllCoinCollected methods
    public UnityEvent<PlayerInventory> onCoinCollected;
    public UnityEvent<PlayerInventory> onAllCoinCollected;
    public int coinCount {get; private set;}
    
    // increment player score and ensure whether all coins are collected
    public void CoinCollected(){
        coinCount++;
        onCoinCollected.Invoke(this);
        if (coinCount == 5)
        {
            onAllCoinCollected.Invoke(this);
        }
    }
}
