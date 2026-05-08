using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownDmg : MonoBehaviour
{
    public Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.gameObject.GetComponent<PlayerController>().GetDamage();
        }
    }
}
