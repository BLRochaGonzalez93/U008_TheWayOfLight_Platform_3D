using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDmg : MonoBehaviour
{
    public float timer;

    private void Update()
    {
        if (gameObject.activeSelf == true)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 10f)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<PlayerController>().GetDamage();
        }
    }
}
