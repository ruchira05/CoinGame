// Display score UI component script
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    TextMeshProUGUI coinnText;
    // Start is called before the first frame update
    void Start()
    {
        coinnText = GetComponent<TextMeshProUGUI>(); // get TextMeshProUGUI component
    }

    //When this teigglerd, will update the UI
    public void UpdateText(PlayerInventory playerInventory){
        coinnText.text = playerInventory.coinCount.ToString();
    }
}
