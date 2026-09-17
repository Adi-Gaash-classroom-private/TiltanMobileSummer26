using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Reads the phone's 3D orientation (attitude) and logs pitch/yaw/roll.
/// Attach to any GameObject. Open the Console to see live values.
///
/// Useful for debugging sensor readings during tilt-to-steer development.
/// </summary>
public class AttitudeWatcher : MonoBehaviour
{
    void Awake()
    {
        if (AttitudeSensor.current != null)
            InputSystem.EnableDevice(AttitudeSensor.current);
    }

    void Update()
    {
        if (AttitudeSensor.current == null) return;

        // .attitude gives a Quaternion (4D rotation)
        // .eulerAngles converts it to pitch (X), yaw (Y), roll (Z)
        Vector3 e = AttitudeSensor.current.attitude.ReadValue().eulerAngles;
        Debug.Log("pitch " + e.x + "   yaw " + e.y + "   roll " + e.z);
    }
}
