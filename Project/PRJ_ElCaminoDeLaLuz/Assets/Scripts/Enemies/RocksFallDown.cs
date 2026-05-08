using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksFallDown : MonoBehaviour
{
    public List<GameObject> rockTypes;
    public List<GameObject> rocks;
    public float gravity;
    public float timer;


    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject go = Instantiate(rockTypes[Random.Range(0, rockTypes.Count)], transform.GetChild(i).transform.position, transform.GetChild(i).transform.rotation);
            go.transform.SetParent(transform.GetChild(i));
            go.SetActive(false);
            rocks.Add(go);
        }
    }

    private void Update()
    {
        timer += 1 * Time.deltaTime;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount == 0)
            {
                GameObject go = Instantiate(rockTypes[Random.Range(0, rockTypes.Count)], transform.GetChild(i).transform.position, transform.GetChild(i).transform.rotation);
                go.transform.SetParent(transform.GetChild(i));
                go.SetActive(false);
                rocks.Add(go);
            }
        }

        for (int i = 0; i < rocks.Count; i++)
        {
            if (rocks[i].gameObject == null)
            {
                rocks.RemoveAt(i);
            }
        }
    }

    public void FallDown()
    {
        for (int i = 0; i < rocks.Count; i++)
        {
            rocks[i].SetActive(true);
            rocks[i].gameObject.transform.SetParent(null);
            rocks[i].GetComponent<Rigidbody>().AddForce(Vector3.down * gravity, ForceMode.Force);
            timer = 0;
        }
    }
}
