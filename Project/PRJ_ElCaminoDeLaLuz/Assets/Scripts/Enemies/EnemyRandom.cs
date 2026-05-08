using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandom : MonoBehaviour
{
    [SerializeField] private int rutine;
    [SerializeField] private float chrono;
    [SerializeField] private Animator anim;
    [SerializeField] private Quaternion angle;
    [SerializeField] private float grade;

    private void Update()
    {
        EnemyBehaviour();
    }

    public void EnemyBehaviour()
    {
        chrono += Time.deltaTime;
        if (chrono>=4)
        {
            rutine = Random.Range(0, 2);
            chrono = 0;
        }

        switch (rutine)
        {
            case 0:
                anim.SetBool("Walk", false);
                break;
            case 1:
                grade = Random.Range(0, 360);
                angle = Quaternion.Euler(0, grade, 0);
                rutine++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                transform.Translate(Vector3.forward * 5 * Time.deltaTime);
                anim.SetBool("Walk", true);
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpecialAttack"))
        {
            gameObject.GetComponent<DestroyObjects>().GetHits();
        }
    }
}
