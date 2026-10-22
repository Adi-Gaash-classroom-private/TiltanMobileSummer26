using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace TiltanMobileSummer2026
{
    /// <summary>
    /// Logs a PASS/CHECK line per checklist row so the student can
    /// point at one screen that says what passes and what to fix.
    /// </summary>
    public class PlayReadinessChecker : MonoBehaviour
    {
        // Google raises this requirement yearly — verify the current
        // value in Play Console before shipping; this is a start only.
        [SerializeField] int minTargetApiForPlay = 34;

        // Unity's Android default — covers the vast majority of devices.
        [SerializeField] int minSdkFloor = 24;

        // Anything less is a very old device; warn, do not block.
        [SerializeField] int minDeviceRamMb = 2048;

        void OnEnable()
        {
            Report("package name", Application.identifier, true);
            Report("app version", Application.version, true);

            int target = 0;
#if UNITY_EDITOR
            target = (int)PlayerSettings.Android.targetSdkVersion;
#endif
            
            Report("target API level", target.ToString(), target >= minSdkFloor);
            if (target < minTargetApiForPlay)
            {
                Debug.LogWarning("[ShipCheck] target API " + target +
                    " is below a recent Play requirement (" + minTargetApiForPlay +
                    "). Check Play Console for the CURRENT value, then retest.");
            }

            int ram = SystemInfo.systemMemorySize;
            Report("device RAM (MB)", ram.ToString(), ram >= minDeviceRamMb);

            Report("operating system", SystemInfo.operatingSystem, true);
            Report("analytics consent",
                   AnalyticsManager.ConsentGranted ? "ON" : "OFF",
                   AnalyticsManager.ConsentGranted);

            Debug.Log("[ShipCheck] done. 64-bit (ARM64) and bundle size are " +
                "BUILD-time checks — verify them in Player Settings / Build Settings.");
        }

        void Report(string what, string value, bool ok)
        {
            string line = "[ShipCheck] " + (ok ? "PASS   " : "CHECK  ") + " " +
                          what + " = " + value;
            if (ok)
            {
                Debug.Log(line);
            }
            else
            {
                Debug.LogWarning(line);
            }
        }
    }
}
