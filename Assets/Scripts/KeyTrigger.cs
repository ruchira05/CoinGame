// Key stage Trigger Script
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    // Public Variables
    public GameObject key; // get object from Unity
    public float keyOpenDuration = 2f;
    public Vector3 keyOpenVector = new Vector3(0f,7f,0f);

    // Private Variables
    AudioManager audioManager;
    private bool isOpening = false;
    private bool isFullyOpen =false;
    private float openStartTime = 0f;
    private Vector3 keyStartPosition;
    private bool isAllCoinCollected = false;

    // Start is called before the first frame update
    void Start()
    {   
        // Ref for audio manager
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        // Get Key start position
        keyStartPosition = key.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // Appear the key step by step
        if(isOpening){
            float openTimeElapsed = Time.time -openStartTime; // calculate opened duration
            if (openTimeElapsed <= keyOpenDuration)
            {
                float keyProgress = openTimeElapsed / keyOpenDuration; // calculate the multiple factor for cost time
                key.transform.position = keyStartPosition + keyOpenVector * keyProgress; // move the key
            }
            else{
                //stop after the desired duration
                isOpening = false;
                isFullyOpen = true;
            }
        }
    }

    // when player hit second collition box this will triggered
    private void OnTriggerEnter(Collider other) {
        // When all coins collected and hit second collition box this will executed
        if (other.CompareTag("Player") && !isFullyOpen && isAllCoinCollected && !isOpening)
        {
            isOpening = true;
            openStartTime = Time.time; // get current game time ref for apper the key
            audioManager.PlaySFX(audioManager.win); // play SFX

        }
    }

    // check whether all coins collected
    public void getIsAllCoinCollected(){
        isAllCoinCollected = true;
    }
}
