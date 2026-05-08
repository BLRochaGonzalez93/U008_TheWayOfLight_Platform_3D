using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraScript : MonoBehaviour
{
    [SerializeField] private Transform CameraFollowTargetTransform;

    [SerializeField] private CameraFollowTarget CameraFollowTarget;

    private CinemachineRecomposer _recomposer;

    private Vector3 _eulerAngles;

    private void Start()
    {
        _recomposer = GetComponent<CinemachineRecomposer>();
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        _eulerAngles = transform.rotation.eulerAngles;
        _eulerAngles.y = CameraFollowTargetTransform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(_eulerAngles);

        _recomposer.m_Tilt = CameraFollowTarget.GetTilt();
        _recomposer.m_Pan = CameraFollowTarget.GetPan();
    }
}