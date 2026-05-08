using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public PlayerController player;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI gemsText;
    [SerializeField] TextMeshProUGUI keysText;
    [SerializeField] TextMeshProUGUI lockpicksText;

    void Start()
    {
        player.SetLives(PlayerPrefs.GetInt("Lives"));
        player.SetCoins(PlayerPrefs.GetInt("Coins"));
        player.SetGems(PlayerPrefs.GetInt("Gems"));
        player.SetKeys(PlayerPrefs.GetInt("Keys"));
        player.SetLockpicks(PlayerPrefs.GetInt("Lockpicks"));
    }

    private void FixedUpdate()
    {
        livesText.text = player.GetLives().ToString();
        coinText.text = player.GetCoins().ToString();
        gemsText.text = player.GetGems().ToString();
        keysText.text = player.GetKeys().ToString();
        lockpicksText.text = player.GetLockpicks().ToString();
    }
}
