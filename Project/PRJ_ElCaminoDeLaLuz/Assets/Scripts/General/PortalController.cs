using UnityEngine;

public class PortalController : MonoBehaviour
{
    public int scene;
    public PlayerController player;
    public int keysNeeded;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (PlayerPrefs.HasKey("Keys") && PlayerPrefs.GetInt("Keys") >= keysNeeded)
        {
            gameObject.GetComponent<SphereCollider>().enabled = true;
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Lives", player.GetLives());
            PlayerPrefs.SetInt("Coins", player.GetCoins());
            PlayerPrefs.SetInt("Gems", player.GetGems());
            PlayerPrefs.SetInt("Keys", player.GetKeys());
            PlayerPrefs.SetInt("Lockpicks", player.GetLockpicks());
            transform.gameObject.GetComponent<MainMenu>().LoadLevel(scene);
        }
    }

}
