using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI gemsText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI keysText;
    [SerializeField] TextMeshProUGUI lockpicksText;

    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
        gemsText = GetComponent<TextMeshProUGUI>();
        livesText = GetComponent<TextMeshProUGUI>();
        keysText = GetComponent<TextMeshProUGUI>();
        lockpicksText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCoinsText(PlayerInventory playerInventory)
    {
        coinText.text = playerInventory.NumberOfCoins.ToString();
    }
    public void UpdateLivesText(PlayerInventory playerInventory)
    {
        livesText.text = playerInventory.NumberOfLives.ToString();
    }
    public void UpdateGemsText(PlayerInventory playerInventory)
    {
        gemsText.text = playerInventory.NumberOfGems.ToString();
    }
    public void UpdateKeysText(PlayerInventory playerInventory)
    {
        keysText.text = playerInventory.NumberOfKeys.ToString();
    }
    public void UpdateLockpicksText(PlayerInventory playerInventory)
    {
        lockpicksText.text = playerInventory.NumberOfLockpicks.ToString();
    }
}
