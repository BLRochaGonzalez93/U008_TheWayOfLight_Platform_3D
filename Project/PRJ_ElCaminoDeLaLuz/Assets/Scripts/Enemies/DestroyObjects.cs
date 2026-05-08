using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestroyObjects : MonoBehaviour
{
    [SerializeField] private int hits = 1;
    [SerializeField] private GameObject toDestroy;
    [SerializeField] private Animator animController;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float animTransition;
    [SerializeField] private List<GameObject> dropList;

    public void GetHits(int hit = 1)
    {
        hits -= hit;
        if (hits <= 0)
        {
            if (transform.CompareTag("Destructible") && transform.gameObject.layer == 9)
            {
                toDestroy.SetActive(false);
            }
            if (transform.CompareTag("Interactuable") && transform.gameObject.layer == 9)
            {
                int rng = Random.Range(1, transform.GetChild(0).childCount);
                for (int i = 0; i < rng; i++)
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
                    transform.GetChild(0).GetChild(i).Translate(Random.Range(-2, 2), Random.Range(0, 2), Random.Range(-2, 2));
                }
                transform.GetChild(0).SetParent(transform.parent.transform);
                toDestroy.SetActive(false);
            }
            else if (transform.CompareTag("Enemy"))
            {
                if (gameObject.GetComponent<EnemyFollowerControl>() != null)
                {
                    gameObject.GetComponent<EnemyFollowerControl>().enabled = false;
                    StartCoroutine("Death");
                }
                if (gameObject.GetComponent<EnemyInfiniteFollower>() != null)
                {
                    gameObject.GetComponent<EnemyInfiniteFollower>().enabled = false;
                    StartCoroutine("Death");
                }
            }
        }
    }

    private IEnumerator Death()
    {
        agent.speed = 0;
        agent.isStopped = true;
        animController.CrossFade("Death", animTransition);
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < dropList.Count; i++)
        {
            Instantiate(dropList[i].gameObject, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), Quaternion.identity);
        }
        toDestroy.SetActive(false);
    }

    public void ChargeDropList(List<GameObject> drops)
    {
        for (int i = 0; i < drops.Count; i++)
        {
            if (drops[i] != null)
            {
                dropList.Add(drops[i]);
            }
        }
    }

    public int NumHits()
    {
        return hits;
    }

    
}
