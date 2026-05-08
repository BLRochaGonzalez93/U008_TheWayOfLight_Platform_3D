using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerCameraChange : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] public CinemachineVirtualCamera CameraForward;
    [SerializeField] public CinemachineVirtualCamera CameraBackwards;
    [SerializeField] public CinemachineVirtualCamera CameraSide;
    [SerializeField] public CinemachineVirtualCamera Camera2DSide;
    [SerializeField] public CinemachineVirtualCamera CameraFinalWall;
    [SerializeField] public CinemachineVirtualCamera CameraChess;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform panel;

    private Vector3 _playerForward;
    private int _orientation; //-1 backwards, 0 unknown, 1 forward

    private void Start()
    {
        _orientation = 0;
    }

    private void Update()
    {
        //Update the current player forward (where the player is looking)
        _playerForward = transform.forward;
        _playerForward.Set(_playerForward.x, 0f, _playerForward.z);


        if (CameraFinalWall != null && CameraFinalWall.Priority == 3 && playerInput.actions["Exit"].WasPressedThisFrame())
        {
            CameraForward.enabled = true;
            CameraBackwards.enabled = true;
            if (CameraFinalWall != null)
            {
                CameraFinalWall.Priority = 1;
            }
            if (CameraForward != null)
            {
                CameraForward.Priority = 3;
            }
            if (CameraBackwards != null)
            {
                CameraBackwards.Priority = 1;
            }
            playerInput.SwitchCurrentActionMap("Player");
        }

        if (_orientation != 1 && _playerForward.x >= 0)
        {
            _orientation = 1;
            if (CameraFinalWall != null)
            {
                CameraFinalWall.Priority = 1;
            }
            if (CameraForward != null)
            {
                CameraForward.Priority = 3;
            }
            if (CameraBackwards != null)
            {
                CameraBackwards.Priority = 1;
            }
            if (Camera2DSide != null)
            {
                Camera2DSide.Priority = 1;
            }
            if (CameraSide != null)
            {
                CameraSide.Priority = 1;
            }
            if (CameraChess != null)
            {
                CameraChess.Priority = 1;
            }
        }
        else if (_orientation != -1 && _playerForward.x < 0)
        {
            _orientation = -1;
            if (CameraFinalWall != null)
            {
                CameraFinalWall.Priority = 1;
            }
            if (CameraForward != null)
            {
                CameraForward.Priority = 1;
            }
            if (CameraBackwards != null)
            {
                CameraBackwards.Priority = 3;
            }
            if (Camera2DSide != null)
            {
                Camera2DSide.Priority = 1;
            }
            if (CameraSide != null)
            {
                CameraSide.Priority = 1;
            }
            if (CameraChess != null)
            {
                CameraChess.Priority = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Level2_CameraSide"))
        {
            if (CameraFinalWall != null)
            {
                CameraFinalWall.Priority = 1;
            }
            if (CameraForward != null)
            {
                CameraForward.Priority = 1;
                CameraForward.enabled = false;
            }
            if (CameraBackwards != null)
            {
                CameraBackwards.Priority = 1;
                CameraBackwards.enabled = false;
            }
            if (Camera2DSide != null)
            {
                Camera2DSide.Priority = 1;
            }
            if (CameraSide != null)
            {
                CameraSide.Priority = 3;
            }
            if (CameraChess != null)
            {
                CameraChess.Priority = 1;
            }
        }

        if (other.CompareTag("Level2_CameraFW"))
        {
            if (CameraFinalWall != null)
            {
                CameraFinalWall.Priority = 1;
            }
            if (CameraForward != null)
            {
                CameraForward.Priority = 1;
                CameraForward.enabled = true;
            }
            if (CameraBackwards != null)
            {
                CameraBackwards.Priority = 3;
                CameraBackwards.enabled = true;
            }
            if (Camera2DSide != null)
            {
                Camera2DSide.Priority = 1;
            }
            if (CameraSide != null)
            {
                CameraSide.Priority = 1;
            }
            if (CameraChess != null)
            {
                CameraChess.Priority = 1;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactuable") && other.gameObject.layer == 10 && playerInput.actions["Interact"].WasPressedThisFrame())
        {
            if (CameraFinalWall != null)
            {
                CameraFinalWall.Priority = 1;
            }
            if (CameraForward != null)
            {
                CameraForward.Priority = 1;
                CameraForward.enabled = false;
            }
            if (CameraBackwards != null)
            {
                CameraBackwards.Priority = 1;
                CameraBackwards.enabled = false;
            }
            if (Camera2DSide != null)
            {
                Camera2DSide.Priority = 5;
            }
            if (CameraSide != null)
            {
                CameraSide.Priority = 1;
            }
            if (CameraChess != null)
            {
                CameraChess.Priority = 1;
            }
            transform.position = new Vector3(-141f, 70f, 185f);
            playerInput.SwitchCurrentActionMap("Player2D");
        }

        if (other.CompareTag("Interactuable") && other.gameObject.layer == 15 && playerInput.actions["Interact"].WasPressedThisFrame())
        {
            if (CameraFinalWall != null)
            {
                CameraFinalWall.Priority = 1;
            }
            if (CameraForward != null)
            {
                CameraForward.Priority = 1;
                CameraForward.enabled = false;
            }
            if (CameraBackwards != null)
            {
                CameraBackwards.Priority = 1;
                CameraBackwards.enabled = false;
            }
            if (Camera2DSide != null)
            {
                Camera2DSide.Priority = 1;
            }
            if (CameraSide != null)
            {
                CameraSide.Priority = 1;
            }
            if (CameraChess != null)
            {
                CameraChess.Priority = 3;
            }
            panel.gameObject.SetActive(true);
            playerInput.SwitchCurrentActionMap("PlayerChess");
            panel.GetComponent<LockPickPuzzle>().BeginLockpicking();
        }

        if (other.CompareTag("FinalWall") && other.gameObject.layer == 12 && playerInput.actions["Interact"].WasPressedThisFrame())
        {
            if (CameraFinalWall != null)
            {
                CameraFinalWall.Priority = 5;
            }
            if (CameraForward != null)
            {
                CameraForward.Priority = 1;
                CameraForward.enabled = false;
            }
            if (CameraBackwards != null)
            {
                CameraBackwards.Priority = 1;
                CameraBackwards.enabled = false;
            }
            if (Camera2DSide != null)
            {
                Camera2DSide.Priority = 1;
            }
            if (CameraSide != null)
            {
                CameraSide.Priority = 1;
            }
            if (CameraChess != null)
            {
                CameraChess.Priority = 1;
            }
            playerInput.SwitchCurrentActionMap("PlayerPuzzle");
            Collider[] cols =  other.GetComponents<Collider>();
            cols[1].enabled = false;
        }
    }
}

