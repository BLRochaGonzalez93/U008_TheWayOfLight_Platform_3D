using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    public Transform respawn;
    [SerializeField] AudioSource checkpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger: " + other.tag);
            checkpoint.Play();
            other.GetComponent<PlayerController>().respawnPoint = respawn.position;
        }
    }
}
