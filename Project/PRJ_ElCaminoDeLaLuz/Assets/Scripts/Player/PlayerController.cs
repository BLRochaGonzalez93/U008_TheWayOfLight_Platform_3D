using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private GameObject meshChild;
    [SerializeField] private LayerMask maskGround;
    [SerializeField] private int lifes;
    [SerializeField] private int coins;
    [SerializeField] private int gems;
    [SerializeField] private int keys;
    [SerializeField] private int lockpicks;

    [Header("Movement")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform groundPoint;
    [SerializeField] private Vector3 levelStartPosition;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpForce;
    [SerializeField] private float airJumpForce;
    [SerializeField] private float speed;
    [SerializeField] private int totalAirJumps;
    [SerializeField] private bool isGrounded;
    private Vector2 move;
    private int currentAirJumps;

    [Header("Rolling Dash")]
    public float dashForce;
    public float dashCdTimer;


    [Header("Combat")]
    public EnemyPool[] pools;

    public Vector3 respawnPoint;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        playerAnim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Lives") != 0)
        {
            lifes = PlayerPrefs.GetInt("Lives");
        }
        respawnPoint = new Vector3(0f, 6f, 50f);
    }

    private void Update()
    {
        if (playerInput.actions["Info"].WasPressedThisFrame())
        {
            gameObject.GetComponent<PlayerInventory>().StartCoroutine("ShowCoinsNumber");
            gameObject.GetComponent<PlayerInventory>().StartCoroutine("ShowLivesNumber");
            gameObject.GetComponent<PlayerInventory>().StartCoroutine("ShowGemsNumber");
            gameObject.GetComponent<PlayerInventory>().StartCoroutine("ShowKeysNumber");
            gameObject.GetComponent<PlayerInventory>().StartCoroutine("ShowLockpicksNumber");
        }

        move = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 dir = new Vector3(move.x, 0f, move.y).normalized;

        if (dir != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
        }
        float movementInput = Mathf.Clamp01(new Vector3(move.x, 0, move.y).magnitude);

        if (move != Vector2.zero)
        {
            if (!playerInput.actions["Run"].IsPressed())
            {
                movementInput /= 2;
                
            }
        }
        playerAnim.SetFloat("Motion", movementInput, 0.2f, Time.deltaTime);


        rb.linearVelocity = new Vector3(move.x * speed * (movementInput * 2) * Time.deltaTime, rb.linearVelocity.y, move.y * speed * (movementInput * 2) * Time.deltaTime);

        isGrounded = Physics.OverlapSphere(groundPoint.position, 0.5f, maskGround).Length > 0;
        playerAnim.SetBool("isGround", isGrounded);

        if (isGrounded)
        {
            currentAirJumps = 0;
            if (playerInput.actions["Jump"].WasPressedThisFrame())
            {
                playerAnim.Play("Knight_Jump");
                playerAnim.SetInteger("Hit", 0);
                gameObject.GetComponent<Fight>().consecutiveAttacks = 0;
                rb.linearVelocity *= 0;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else if (playerInput.actions["Roll"].WasPressedThisFrame())
            {
                playerAnim.Play("Knight_Roll");
                playerAnim.SetInteger("Hit", 0);
                gameObject.GetComponent<Fight>().consecutiveAttacks = 0;
                rb.linearVelocity *= 0;
                rb.AddForce(Vector3.forward * 5, ForceMode.Impulse);
                isGrounded = false;
            }
        }
        else
        {
            if (playerInput.actions["Jump"].WasPressedThisFrame() && currentAirJumps < totalAirJumps)
            {
                playerAnim.SetInteger("Hit", 0);
                gameObject.GetComponent<Fight>().consecutiveAttacks = 0;
                playerAnim.Play("Knight_Jump");
                rb.linearVelocity *= 0;
                rb.AddForce(Vector3.up * airJumpForce, ForceMode.Impulse);

                currentAirJumps++;
            }
            rb.AddForce(Vector3.down * gravity, ForceMode.Force);
        }

        if (playerInput.actions["Reset"].WasPressedThisFrame())
        {
            //A�adir aqui el codigo necesario cuando interactuas con el entorno
            /*Codigo de ejemplo*/
            for (int i = 0; i < pools.Length; i++)
            {
                pools[i].RespawnAllEnemies();
            }
        }
    }

    public int GetLives()
    {
        return lifes;
    }
    public int GetCoins()
    {
        return coins;
    }
    public int GetGems()
    {
        return gems;
    }
    public int GetKeys()
    {
        return keys;
    }
    public int GetLockpicks()
    {
        return lockpicks;
    }


    public void SetLives(int lives)
    {
        lifes = lives;
        PlayerPrefs.SetInt("Lives", lifes);
    }
    public void SetCoins(int c)
    {
        coins = c;
        PlayerPrefs.SetInt("Coins", coins);
    }
    public void SetGems(int g)
    {
        gems = g;
        PlayerPrefs.SetInt("Gems", gems);
    }
    public void SetKeys(int k)
    {
        keys = k;
        PlayerPrefs.SetInt("Keys", keys);
    }
    public void SetLockpicks(int lp)
    {
        lockpicks = lp;
        PlayerPrefs.SetInt("Lockpicks", lockpicks);
    }


    public void GetDamage()
    {
        lifes--;
        if (lifes <= 0)
        {
            StartCoroutine("Death");
        }
        else
        {
            StartCoroutine("Restart");
        }
    }

    public IEnumerator Restart()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        playerInput.enabled = false;
        playerAnim.SetTrigger("Death");
        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetInt("Lives", lifes);
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        playerAnim.Play("Motion");
        playerInput.enabled = true;
        transform.position = respawnPoint;
        if (gameObject.GetComponent<PlayerCameraChange>().CameraForward != null)
        {
            gameObject.GetComponent<PlayerCameraChange>().CameraForward.Priority = 3;
            gameObject.GetComponent<PlayerCameraChange>().CameraForward.enabled = true;
        }
        if (gameObject.GetComponent<PlayerCameraChange>().CameraBackwards != null)
        {
            gameObject.GetComponent<PlayerCameraChange>().CameraBackwards.enabled = true;
            gameObject.GetComponent<PlayerCameraChange>().CameraBackwards.Priority = 1;
        }
        if (gameObject.GetComponent<PlayerCameraChange>().Camera2DSide != null)
        {
            gameObject.GetComponent<PlayerCameraChange>().Camera2DSide.Priority = 1;
        }
        if (gameObject.GetComponent<PlayerCameraChange>().CameraSide != null)
        {
            gameObject.GetComponent<PlayerCameraChange>().CameraSide.Priority = 1;
        }
        StartCoroutine("ShowCollectables");
    }

    public IEnumerator Death()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        playerAnim.SetTrigger("Death");
        yield return new WaitForSeconds(2f);
        lifes += 3;
        PlayerPrefs.SetInt("Lives", lifes);
        SceneManager.LoadScene(1);
    }

    public IEnumerator ShowCollectables()
    {
        transform.gameObject.GetComponent<PlayerInventory>().coinsHUD.GetComponent<Animator>().SetBool("CoinCollected", true);
        transform.gameObject.GetComponent<PlayerInventory>().gemsHUD.GetComponent<Animator>().SetBool("GemCollected", true);
        transform.gameObject.GetComponent<PlayerInventory>().livesHUD.GetComponent<Animator>().SetBool("LifeAdded", true);
        transform.gameObject.GetComponent<PlayerInventory>().keysHUD.GetComponent<Animator>().SetBool("KeyCollected", true);
        transform.gameObject.GetComponent<PlayerInventory>().lockpicksHUD.GetComponent<Animator>().SetBool("LockpickCollected", true);
        yield return new WaitForSeconds(1.5f);
        transform.gameObject.GetComponent<PlayerInventory>().coinsHUD.GetComponent<Animator>().SetBool("CoinCollected", false);
        transform.gameObject.GetComponent<PlayerInventory>().gemsHUD.GetComponent<Animator>().SetBool("GemCollected", false);
        transform.gameObject.GetComponent<PlayerInventory>().livesHUD.GetComponent<Animator>().SetBool("LifeAdded", false);
        transform.gameObject.GetComponent<PlayerInventory>().keysHUD.GetComponent<Animator>().SetBool("KeyCollected", false);
        transform.gameObject.GetComponent<PlayerInventory>().lockpicksHUD.GetComponent<Animator>().SetBool("LockpickCollected", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyAttack"))
        {
            GetDamage();
        }
        if (other.CompareTag("TailShockRock"))
        {
            GetDamage();
            GameObject.Destroy(other.gameObject);
        }
    }
}
