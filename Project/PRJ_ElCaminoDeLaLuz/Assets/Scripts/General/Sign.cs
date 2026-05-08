using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject panel;

    public SpriteRenderer panelPropio;

   
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            panel.transform.parent.gameObject.SetActive(true);
            panel.GetComponent<Image>().sprite = panelPropio.sprite;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            panel.transform.parent.gameObject.SetActive(false);
           
        }
    }
}
