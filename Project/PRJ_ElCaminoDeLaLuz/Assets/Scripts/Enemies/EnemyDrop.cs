using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public List<GameObject> items;
    public List<int> dropChance;
    public GameObject ePool;

    private void Start()
    {
        StartCoroutine("ChargeEnemies");
    }

    public IEnumerator ChargeEnemies()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < ePool.GetComponent<EnemyPool>().enemies.Count; i++)
        {
            ePool.GetComponent<EnemyPool>().enemies[i].gameObject.GetComponentInChildren<DestroyObjects>().ChargeDropList(ChargeDrop());
        }
    }

    public List<GameObject> ChargeDrop()
    {
        List<GameObject> possibleItems = new List<GameObject>();
        int n = 100;
        while(n > 0)
        {
            int randomNumber = Random.Range(1, 101); //35
            n -= randomNumber;
            possibleItems.Add(GetDroppedItem(randomNumber));
        }
        if (possibleItems.Count != 0)
        {
            for (int i = 0; i < possibleItems.Count; i++)
            {
                if (possibleItems[i] == null)
                {
                    possibleItems.RemoveAt(i);
                }
            }
        }
        return possibleItems;
    }

    public GameObject GetDroppedItem(int rng)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (rng <= dropChance[i])
            {
                return items[i];
            }
        }
        return null;
    }
}
