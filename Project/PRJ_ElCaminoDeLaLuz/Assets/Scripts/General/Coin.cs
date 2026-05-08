using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float detectionRange;
    [SerializeField] private Transform player;
    
    [SerializeField] private float minSpeedMod;
    [SerializeField] private float maxSpeedMod;

    public int keyLevelNumber;

    Vector3 speed = Vector3.zero;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist <= detectionRange)
        {
            transform.parent.position = Vector3.SmoothDamp(transform.position, player.position, ref speed, Time.deltaTime * Random.Range(minSpeedMod, maxSpeedMod));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (transform.CompareTag("Coin"))
            {
                other.GetComponent<PlayerInventory>().CoinCollected();
            }

            if (transform.CompareTag("GemTag"))
            {
                other.GetComponent<PlayerInventory>().GemCollected();
            }

            if (transform.CompareTag("LockpickTag"))
            {
                other.GetComponent<PlayerInventory>().LockpickCollected();
            }

            if (transform.CompareTag("KeyTag"))
            {
                if (keyLevelNumber > PlayerPrefs.GetInt("Keys"))
                {
                    other.GetComponent<PlayerInventory>().KeyCollected();
                    PlayerPrefs.SetInt("Keys", keyLevelNumber);
                }
            }
            transform.parent.gameObject.SetActive(false);
        }
    }
}
