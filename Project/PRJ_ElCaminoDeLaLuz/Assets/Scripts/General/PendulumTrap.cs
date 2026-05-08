using UnityEngine;

public enum Axis { X, Y, Z}

public class PendulumTrap : MonoBehaviour
{
    [SerializeField] private float speed, limit;
    [SerializeField] private Axis axis;

    void Update()
    {
        Vector3 dir = Vector3.zero;
        float newMovement = 90 + limit * Mathf.Sin(Time.time * speed);

        switch (axis)
        {
            case Axis.X:
                dir.x = newMovement;
                break;
            case Axis.Y:
                dir.y = newMovement;
                break;
            case Axis.Z:
                dir.z = newMovement;
                break;
            default:
                break;
        }

        transform.localRotation = Quaternion.Euler(dir);
    }
}
