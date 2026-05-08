using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float fireBallSpeed;

    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer > 3f)
        {
            GameObject.Destroy(gameObject);
            timer = 0;
        }

        transform.Translate(Vector3.forward * fireBallSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collider: " + collision);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Alcanzado");
            gameObject.GetComponent<DestroyObjects>().GetHits();
        }
    }
}
