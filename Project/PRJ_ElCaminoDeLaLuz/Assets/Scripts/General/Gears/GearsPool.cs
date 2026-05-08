using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GearsPool : MonoBehaviour
{
    [SerializeField] public List<Transform> listGears;
    [SerializeField] public List<Transform> listAxis;
    [SerializeField] public List<bool> listValidators;
    [SerializeField] public Animator gearAnim, doorAnim;
    [SerializeField] public PlayerCameraChange player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCameraChange>();
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            listGears.Add(transform.GetChild(0).GetChild(i));
        }
        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            listAxis.Add(transform.GetChild(1).GetChild(i));
        }
        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            listValidators.Add(false);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < listAxis.Count; i++)
        {
            if (listAxis[i].transform.position.x == listGears[i].transform.position.x && listAxis[i].transform.position.z == listGears[i].transform.position.z)
            {
                listValidators[i] = true;
            }
            else
            {
                listValidators[i] = false;
            }
        }

        int count = 0;
        foreach (bool item in listValidators)
        {
            if (item == true)
            {
                count++;
            }
        }

        if (count == 3)
        {
            StartCoroutine("AllGearsChecked");
        }
    }

    private IEnumerator AllGearsChecked()
    {
        foreach (Transform item in listGears)
        {
            item.gameObject.GetComponent<DragDropable>().enabled = false;
        }
        yield return new WaitForSeconds(.5f);
        gearAnim.SetBool("AllChecked", true);
        yield return new WaitForSeconds(1f);
        player.CameraFinalWall.Priority = 1;
        player.CameraForward.enabled = true;
        player.CameraBackwards.enabled = true;
        player.CameraForward.Priority = 3;
        doorAnim.SetBool("Rotate", true);
        player.gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
    }
}
