using UnityEngine;
using UnityEngine.InputSystem;


public class ShakeDetector : MonoBehaviour
{
    [SerializeField] float threshold = 2f;

    Vector3 lastAccel;
    bool hasLast;

    void Awake()
    {
        if (Accelerometer.current != null)
            InputSystem.EnableDevice(Accelerometer.current);
    }

    void Update()
    {
        if (Accelerometer.current == null) return;

        Vector3 current = Accelerometer.current.acceleration.ReadValue();

        // First frame: no "last" value exists yet
        if (!hasLast)
        {
            lastAccel = current;
            hasLast = true;
            return;
        }

        float delta = (current - lastAccel).magnitude;
        if (delta > threshold)
        {
            Debug.Log("SHAKE!");
        }

        lastAccel = current;
    }

    void OnDestroy()
    {
        if (Accelerometer.current != null)
            InputSystem.DisableDevice(Accelerometer.current);
    }
}
