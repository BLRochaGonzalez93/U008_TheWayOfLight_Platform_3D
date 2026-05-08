using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordInteraction : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<DestroyObjects>() != null)
        {
           
            other.GetComponent<DestroyObjects>().GetHits();
        }
    }
}
