using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TiltanMobileSummer2026
{
    /// <summary>
    /// Session lifecycle events. Ignores accidental opens
    /// shorter than minSessionSeconds (tap-out on the store page).
    /// </summary>
    public class SessionTracker : MonoBehaviour
    {
        [SerializeField] float minSessionSeconds = 5f;

        bool   sessionActive = false;
        float  sessionStart  = 0f;
        string sessionScene  = "";

        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            TryStartSession();
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            EndSession();
        }

        void OnApplicationPause(bool paused)
        {
            if (paused)
            {
                EndSession();
            }
            else
            {
                TryStartSession();
            }
        }

        void OnApplicationQuit()
        {
            EndSession();
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // A scene change mid-session just updates the label.
            if (sessionActive)
            {
                sessionScene = scene.name;
            }
        }

        void TryStartSession()
        {
            if (sessionActive)
            {
                return;
            }
            sessionActive = true;
            sessionStart  = Time.realtimeSinceStartup;
            sessionScene  = SceneManager.GetActiveScene().name;

            var data = new Dictionary<string, object>
            {
                { AnalyticsEvents.KEY_SCENE,     sessionScene },
                { AnalyticsEvents.KEY_DEVICE_OS, SystemInfo.operatingSystem },
            };
            AnalyticsManager.Track(AnalyticsEvents.SESSION_START, data);
        }

        void EndSession()
        {
            if (!sessionActive)
            {
                return;
            }
            sessionActive = false;

            float duration = Time.realtimeSinceStartup - sessionStart;
            if (duration < minSessionSeconds)
            {
                return; // accidental open — not a real session
            }

            var data = new Dictionary<string, object>
            {
                { AnalyticsEvents.KEY_DURATION, Mathf.RoundToInt(duration) },
            };
            AnalyticsManager.Track(AnalyticsEvents.SESSION_END, data);
        }
    }
}
