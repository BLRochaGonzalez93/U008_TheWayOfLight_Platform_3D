using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LockPickPuzzle : MonoBehaviour
{
    [SerializeField] private Animator LockAnimator;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] public PlayerCameraChange player;
    [SerializeField] private List<GameObject> dropList;
    [SerializeField] private GameObject gameHandler;
    public int currentLockpickMovements;

    //This is a list of all the valid sequences for this puzzle. Because of the mechanics of the game, you can never cross a higher number in search of the next number in
    //sequence, but you can cross lower numbers. Also the first tumbler can be anywhere (because until you hit it, the game will just be in default state of all tumblers down)
    //1, 2, 3, 4 is valid but trivial and kind of a bullshit arrangement for exploring how the game works
    int[][] validTumblerArrangements =
        new int[][] {
            //new int[] { 1, 2, 3, 4, 5 },
            new int[] { 2, 1, 3, 4, 5 },
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 5, 1, 2, 3, 4 },
            new int[] { 5, 4, 1, 2, 3 },
            new int[] { 5, 4, 3, 1, 2 },
            new int[] { 5, 4, 3, 2, 1 },
            new int[] { 4, 2, 1, 3, 5 },
            new int[] { 5, 3, 1, 2, 4 },
            new int[] { 5, 3, 2, 1, 4 },
            new int[] { 4, 1, 2, 3, 5 },
            new int[] { 3, 1, 2, 4, 5 },
            new int[] { 5, 4, 2, 1, 3 },
            new int[] { 2, 1, 3, 4, 5 },
            new int[] { 3, 2, 1, 4, 5 },
            new int[] { 5, 4, 3, 1, 2 },
            new int[] { 5, 4, 1, 2, 3 },

};

    //The tumbler we're on
    int currentTumbler;

    //One of the valid sequences from above, chosen at random on game start
    int[] tumblerOrder;

    public int tumblerProgress;

    //The player can toggle hints on
    bool showTarget = false;

    //Track whether each tumbler is solved or not
    bool[] tumblerStatus;

    //UI
    public GameObject Panel;

    //The lockpick object so we can move it around
    public Transform lockpick;

    //The tumblers
    public RectTransform[] tumblers;

    //The numbers that show up over the tumblers for the player hints
    public TMPro.TextMeshProUGUI[] keyDigits;

    //These are values for setting the position of the tumblers in solved (up) and unsolved (down) states
    public float tumblerUpYValue;

    public float tumblerDownYValue;

    //When the pick is under it, raise it up slightly
    public float tumblerActiveYValue;

    //This is a list of all the positions the lockpick is in when it moves across the space. It's easiest to just set this by hand in the editor
    public Vector3[] lockpickPositions;

    public void BeginLockpicking()
    {
        Panel.SetActive(true);
        currentLockpickMovements = 20;
        SetupLock();
    }

    public void EndLockpicking()
    {
        Panel.SetActive(false);
        playerInput.SwitchCurrentActionMap("Player2D");
        player.CameraChess.Priority = 1;
        player.Camera2DSide.Priority = 3;
    }

    //If the player succeeds, open the lock and end the minigame
    public void OnSuccess()
    {
        OpenLock();
        EndLockpicking();
    }

    public void SetupLock()
    {
        showTarget = false;
        currentTumbler = 0;

        //Reset lockpick and tumbler positions
        ResetTumblers();
        lockpick.localPosition = lockpickPositions[0];

        //generate sequence for tumblers - pick from list of valid sequences
        int randomArrangement = Random.Range(0, validTumblerArrangements.Length);
        tumblerOrder = validTumblerArrangements[randomArrangement];

        tumblerProgress = 1;
        ShowHideTarget();
    }

    //This shows or hides the hint digits above the tumblers
    void ShowHideTarget()
    {
        for (int i = 0; i < keyDigits.Length; i++)
        {
            keyDigits[i].gameObject.SetActive(showTarget);
            keyDigits[i].text = tumblerOrder[i].ToString();
        }
    }

    void Awake()
    {
        tumblerStatus = new bool[tumblers.Length];
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCameraChange>();
        playerInput = player.gameObject.GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (playerInput.actions["EscapePuzzle"].WasPressedThisFrame())
        {
            EndLockpicking();
        }

        if (playerInput.actions["Cheat"].WasPressedThisFrame())
        {
            showTarget = !showTarget;
            ShowHideTarget();
        }

        //If the player moves right or left, we increment or decrement the current tumbler, checking our bounds first
        //Then we move the lockpick to the appropriate place and check to see whether or not it was the right move
        if (playerInput.actions["PickRight"].WasPressedThisFrame())
        {
            if (currentTumbler < tumblers.Length - 1)
            {
                currentTumbler += 1;
                currentLockpickMovements--;
                MoveLockpick();
                CheckProgress();
            }
        }
        if (playerInput.actions["PickLeft"].WasPressedThisFrame())
        {
            if (currentTumbler > 0)
            {
                currentTumbler -= 1;
                currentLockpickMovements--;
                MoveLockpick();
                CheckProgress();
            }
        }
        
    }

    private void FixedUpdate()
    {
        Debug.Log(currentLockpickMovements);
        Debug.Log(PlayerPrefs.GetInt("Lockpicks"));
        if (currentLockpickMovements <= 0)
        {
            currentLockpickMovements = 20;
            int locks = PlayerPrefs.GetInt("Lockpicks") - 1;
            PlayerPrefs.SetInt("Lockpicks", locks);
            Debug.Log(PlayerPrefs.GetInt("Lockpicks"));
            player.gameObject.GetComponent<PlayerInventory>().LockpickBroken();
            if (PlayerPrefs.GetInt("Lockpicks") <= 0)
            {
                EndLockpicking();
            }
        }
    }

    IEnumerator SuccessDelay()
    {
        //Do a delay here so that the player can see the tumblers move, etc
        yield return new WaitForSeconds(0.5f);
        OnSuccess();
    }

    //All this does is move the lockpick to the appropriate position depending on the current tumbler index
    void MoveLockpick()
    {
        //TODO: Tween this
        lockpick.localPosition = lockpickPositions[currentTumbler];
    }

    //This checks to see whether the last move we made was the right one, and if so if we're at the end
    void CheckProgress()
    {
        if (tumblerOrder[currentTumbler] == tumblerProgress)
        {
            //We got the right one, so increment the one we're looking for and raise the current tumbler
            tumblerProgress += 1;
            RaiseCurrentTumbler();
            if (tumblerProgress > 5)
            {
                //Success!
                StartCoroutine(SuccessDelay());
            }
        }
        else if (tumblerStatus[currentTumbler])
        {
            //This one is already raised, so just go on
        }
        else
        {
            //We didn't get the right one, so make all tumblers fall (but animate the current one up then down)
            ResetTumblers();
        }
    }

    void RaiseCurrentTumbler()
    {
        //Animate tumbler movement up to y value
        tumblers[currentTumbler].position += new Vector3(0, tumblerUpYValue);
        //Set the tumbler status so that we know it's raised
        tumblerStatus[currentTumbler] = true;
        //Set the position of all the others down (because we animated them up when the lockpick passed by)
        for (int i = 0; i < tumblers.Length; i++)
        {
            if (!tumblerStatus[i])
            {
                tumblers[i].position -= new Vector3(0, tumblerDownYValue);
            }
        }
    }

    //Set the tumbler positions and statuses back to the starting state
    void ResetTumblers()
    {
        tumblerProgress = 1;
        //Drop all tumblers back to lowered position
        foreach (Transform t in tumblers)
        {
            t.localPosition = new Vector3(t.localPosition.x, tumblerDownYValue);
        }
        //Reset their status in the array
        for (int i = 0; i < tumblerStatus.Length; i++)
        {
            tumblerStatus[i] = false;
        }
    }

    public string GetFriendlyName()
    {
        return "LockPick";
    }

    public void OpenLock()
    {
        if (LockAnimator != null)
        {
            LockAnimator.SetTrigger("Open");
            dropList.AddRange(gameHandler.gameObject.GetComponent<EnemyDrop>().ChargeDrop());
            for (int i = 0; i < dropList.Count; i++)
            {
                if (dropList[i] != null)
                {
                    Instantiate(dropList[i].gameObject, new Vector3(LockAnimator.gameObject.transform.position.x, LockAnimator.gameObject.transform.position.y + 2, LockAnimator.gameObject.transform.position.z), Quaternion.identity);
                }
            }
        }
    }
}
