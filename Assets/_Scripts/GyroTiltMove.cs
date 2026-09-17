using UnityEngine;
using UnityEngine.InputSystem;


public class GyroTiltMove : MonoBehaviour
{
    Quaternion starting;
    bool hasStart;

    void Awake()
    {
        if (AttitudeSensor.current != null)
            InputSystem.EnableDevice(AttitudeSensor.current);
    }

    void Update()
    {
        if (AttitudeSensor.current == null) return;

        Quaternion now = AttitudeSensor.current.attitude.ReadValue();

        if (!hasStart)
        {
            starting = now;
            hasStart = true;
        }

        // Delta from starting angle, not raw absolute angle
        Vector3 e = (now * Quaternion.Inverse(starting)).eulerAngles;

        // Clamp to a game-friendly range (a phone on a desk, not a helicopter)
        float tilt = Mathf.Clamp(e.x, -30f, 30f);

        // Move along Z (forward/back) based on tilt
        transform.Translate(0f, 0f, tilt * 0.01f, Space.World);
    }

    void OnDestroy()
    {
        if (AttitudeSensor.current != null)
            InputSystem.DisableDevice(AttitudeSensor.current);
    }
}
