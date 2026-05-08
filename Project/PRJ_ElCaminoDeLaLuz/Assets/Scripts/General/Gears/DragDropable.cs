using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragDropable : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject GearAxis;
    [SerializeField] private Vector3 originalPosition;
    [SerializeField] private List<Vector3> finalPositions;

    private Vector3 currentScreenPosition;

    private Camera newCamera;
    private bool isDragging;

    private Vector3 worldPosition
    {
        get
        {
            float z = newCamera.WorldToScreenPoint(transform.position).z;
            return newCamera.ScreenToWorldPoint(currentScreenPosition + new Vector3(0, 0, z));
        }
    }
    private bool isClickedOn
    {
        get
        {
            Ray ray = newCamera.ScreenPointToRay(currentScreenPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                return hit.transform == transform;
            }
            return false;
        }
    }

    private void Start()
    {
        StartCoroutine("Load");
        newCamera = Camera.main;
        originalPosition = transform.position;
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < GearAxis.GetComponent<GearsPool>().listAxis.Count; i++)
        {
            finalPositions.Add(GearAxis.GetComponent<GearsPool>().listAxis[i].position);
        }
    }

    private void Update()
    {
        currentScreenPosition = playerInput.actions["ScreenPosition"].ReadValue<Vector2>();
        if (playerInput.actions["Grab"].WasPressedThisFrame() && isClickedOn)
        {
            StartCoroutine("Drag");
        }
        if (playerInput.actions["Grab"].WasReleasedThisFrame())
        {
            isDragging = false;
        }
    }

    private IEnumerator Drag()
    {
        Vector3 newPos = Vector3.zero;
        isDragging = true;
        while(isDragging)
        {
            transform.position = worldPosition;
            yield return null;
        }

        for (int i = 0; i < finalPositions.Count; i++)
        {
            
            if (Vector3.Distance(transform.position, finalPositions[i]) < 0.25f)
            {
                newPos = finalPositions[i];
            }

        }
        if (newPos == Vector3.zero)
        {
            transform.position = originalPosition;
        }
        else
        {
            transform.position = newPos;
        }
    }
}
