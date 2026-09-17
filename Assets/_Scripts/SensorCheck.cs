using UnityEngine;
using UnityEngine.InputSystem;
using Gyroscope = UnityEngine.InputSystem.Gyroscope;

/// <summary>
/// Capability check: logs which sensors are available on this device.
/// Run this first — sensors start disabled and can be null on some phones.
///
/// Key pattern: always check .current != null before using any sensor.
/// </summary>
public class SensorCheck : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("accelerometer: " + (Accelerometer.current != null));
        Debug.Log("gyroscope:     " + (Gyroscope.current != null));

        // Enable the accelerometer if it exists on this device
        if (Accelerometer.current != null)
            InputSystem.EnableDevice(Accelerometer.current);
    }
}
