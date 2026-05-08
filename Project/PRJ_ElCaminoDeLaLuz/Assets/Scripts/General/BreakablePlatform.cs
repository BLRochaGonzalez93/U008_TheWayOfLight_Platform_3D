using System.Collections;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    public float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("BreakPlatform");
        }
    }

    IEnumerator BreakPlatform()
    {
        transform.GetComponent<Animator>().Play("Break");
        yield return new WaitForSeconds(2f);
        transform.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(3f);
        transform.GetComponent<Animator>().SetBool("RestoreTime", true);
        yield return new WaitForSeconds(2f);
        transform.GetComponent<Collider>().enabled = true;
        transform.GetComponent<Animator>().SetBool("RestoreTime", false);
    }
}
