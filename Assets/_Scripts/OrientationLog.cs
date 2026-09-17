using UnityEngine;

/// <summary>
/// Logs and sets the device orientation (portrait / landscape).
/// The same Screen.orientation property both reports and controls orientation.
///
/// Four values: Portrait, LandscapeLeft, LandscapeRight, AutoRotation
///
/// Editor emulation: in the Game view's aspect-ratio menu, pick a
/// portrait or landscape device preset — the editor emulates that screen shape.
/// </summary>
public class OrientationLog : MonoBehaviour
{
    void Awake()
    {
        // Portrait, LandscapeLeft, LandscapeRight, AutoRotation
        Debug.Log("held as: " + Screen.orientation);
    }

    void SetPortrait()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
