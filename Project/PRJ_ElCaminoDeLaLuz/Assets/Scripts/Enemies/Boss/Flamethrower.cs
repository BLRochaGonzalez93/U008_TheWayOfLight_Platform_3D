using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float fireBallSpeed;

    void Update()
    {
        transform.Translate(Vector3.forward * fireBallSpeed * Time.deltaTime);
        transform.localScale += new Vector3(3.5f, 3.5f, 3.5f) * Time.deltaTime;

        timer += 1 * Time.deltaTime;

        if (timer > 1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            GameObject.Destroy(gameObject);
            timer = 0;
        }
    }
}
