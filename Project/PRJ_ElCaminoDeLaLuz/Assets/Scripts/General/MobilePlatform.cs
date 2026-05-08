using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MobilePlatform : MonoBehaviour
{
    [SerializeField] private List<Transform> points = new List<Transform>();
    [SerializeField] private Transform pointsSibling;
    [SerializeField] private float speed;
    [SerializeField] private int currenPoint;
    [SerializeField] private bool playerIsOnIt;
    [SerializeField] private PlayerInput playerInput;

    void Start()
    {
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        playerIsOnIt = false;
        for (int i = 0; i < pointsSibling.childCount; i++)
        {
            points.Add(pointsSibling.GetChild(i));
        }
    }

    void FixedUpdate()
    {
        if (playerIsOnIt == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[currenPoint].position, speed * Time.deltaTime);
            if (transform.position == points[currenPoint].position)
            {
                currenPoint++;
                if (currenPoint >= points.Count)
                {
                    currenPoint = points.Count-1;
                    for (int i = 0; i < transform.GetChild(0).childCount; i++)
                    {
                        transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
                    }
                    transform.GetComponent<Collider>().enabled = false;
                    playerInput.gameObject.GetComponent<PlayerCameraChange>().CameraForward.enabled = true;
                    playerInput.gameObject.GetComponent<PlayerCameraChange>().CameraBackwards.enabled = true;
                    playerInput.gameObject.GetComponent<PlayerCameraChange>().CameraForward.Priority = 3;
                    playerInput.gameObject.GetComponent<PlayerCameraChange>().Camera2DSide.Priority = 1;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.GetComponent<MobilePlatform>().enabled = true;
        other.transform.SetParent(transform);
        playerIsOnIt = true;
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
        }
        playerInput.SwitchCurrentActionMap("Player");
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
        transform.GetComponent<MobilePlatform>().enabled = false;
    }
}
