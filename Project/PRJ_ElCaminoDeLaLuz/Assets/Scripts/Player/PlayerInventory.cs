using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfCoins { get; private set; }
    public int NumberOfGems { get; private set; }
    public int NumberOfLives { get; private set; }
    public int NumberOfKeys { get; private set; }
    public int NumberOfLockpicks { get; private set; }

    public UnityEvent<PlayerInventory> OnCoinCollected;
    public UnityEvent<PlayerInventory> OnGemCollected;
    public UnityEvent<PlayerInventory> OnKeyCollected;
    public UnityEvent<PlayerInventory> OnLifeAdded;
    public UnityEvent<PlayerInventory> OnLockpickCollected;
    public GameObject coinsHUD;
    public GameObject gemsHUD;
    public GameObject livesHUD;
    public GameObject keysHUD;
    public GameObject lockpicksHUD;
    public float cTimer = 0;
    public float gTimer = 0;
    public float kTimer = 0;
    public float lTimer = 0;
    public float lpTimer = 0;

    private void Start()
    {
        NumberOfLives = PlayerPrefs.GetInt("Lives");
        NumberOfGems = PlayerPrefs.GetInt("Gems");
        NumberOfCoins = PlayerPrefs.GetInt("Coins");
        NumberOfKeys = PlayerPrefs.GetInt("Keys");
        NumberOfLockpicks = PlayerPrefs.GetInt("Lockpicks");
    }

    private void Update()
    {
        cTimer += Time.deltaTime;
        gTimer += Time.deltaTime;
        kTimer += Time.deltaTime;
        lTimer += Time.deltaTime;
        lpTimer += Time.deltaTime;
    }

    public void CoinCollected()
    {
        NumberOfCoins++;

        if (NumberOfCoins>=100)
        {
            NumberOfCoins = 0;
            LifeAdded(1);
        }
        gameObject.GetComponent<PlayerController>().SetCoins(NumberOfCoins);
        StartCoroutine("ShowCoinsNumber");
        cTimer = 0;
        OnCoinCollected.Invoke(this);
    }

    public void GemCollected()
    {
        NumberOfGems++;

        gameObject.GetComponent<PlayerController>().SetGems(NumberOfGems);
        StartCoroutine("ShowGemsNumber");
        gTimer = 0;
        OnGemCollected.Invoke(this);
    }

    public void KeyCollected()
    {
        NumberOfKeys++;

        gameObject.GetComponent<PlayerController>().SetKeys(NumberOfKeys);
        StartCoroutine("ShowKeysNumber");
        kTimer = 0;
        OnKeyCollected.Invoke(this);
    }
    
    public void LockpickCollected()
    {
        NumberOfLockpicks++;

        gameObject.GetComponent<PlayerController>().SetLockpicks(NumberOfLockpicks);
        StartCoroutine("ShowLockpicksNumber");
        lpTimer = 0;
        OnLockpickCollected.Invoke(this);
    }

    public void LockpickBroken()
    {
        NumberOfLockpicks--;

        gameObject.GetComponent<PlayerController>().SetLockpicks(NumberOfLockpicks);
        StartCoroutine("ShowLockpicksNumber");
        lpTimer = 0;
        OnLockpickCollected.Invoke(this);
    }

    public void LifeAdded(int lives)
    {
        NumberOfLives += lives;
        gameObject.GetComponent<PlayerController>().SetLives(NumberOfLives);
        StartCoroutine("ShowLivesNumber");
        lTimer = 0;
        OnLifeAdded.Invoke(this);
    }

    public IEnumerator ShowCoinsNumber()
    {
        coinsHUD.GetComponent<Animator>().SetBool("CoinCollected", true);
        yield return new WaitForSeconds(1.5f);
        coinsHUD.GetComponent<Animator>().SetBool("CoinCollected", false);
    }

    public IEnumerator ShowGemsNumber()
    {
        gemsHUD.GetComponent<Animator>().SetBool("GemCollected", true);
        yield return new WaitForSeconds(1.5f);
        gemsHUD.GetComponent<Animator>().SetBool("GemCollected", false);
    }

    public IEnumerator ShowKeysNumber()
    {
        keysHUD.GetComponent<Animator>().SetBool("KeyCollected", true);
        yield return new WaitForSeconds(1.5f);
        keysHUD.GetComponent<Animator>().SetBool("KeyCollected", false);
    }

    public IEnumerator ShowLivesNumber()
    {
        livesHUD.GetComponent<Animator>().SetBool("LifeAdded", true);
        yield return new WaitForSeconds(1.5f);
        livesHUD.GetComponent<Animator>().SetBool("LifeAdded", false);
    }

    public IEnumerator ShowLockpicksNumber()
    {
        lockpicksHUD.GetComponent<Animator>().SetBool("LockpickCollected", true);
        yield return new WaitForSeconds(1.5f);
        lockpicksHUD.GetComponent<Animator>().SetBool("LockpickCollected", false);
    }
}
