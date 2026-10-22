using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

namespace TiltanMobileSummer2026
{
    /// <summary>
    /// Static facade over the Unity Analytics API.
    /// No other class in the project should call Analytics.CustomEvent.
    /// </summary>
    public static class AnalyticsManager
    {
        static bool consented = false;

        /// <summary>True once the player has agreed to be measured.</summary>
        public static bool ConsentGranted => consented;

        /// <summary>Player said OK — the kill switch flips on.</summary>
        public static void GrantConsent()
        {
            consented = true;
            Analytics.enabled = true;
            Debug.Log("[Analytics] consent granted — events flow");
        }

        /// <summary>Player said no (or changed their mind) — everything stops.</summary>
        public static void RevokeConsent()
        {
            consented = false;
            Analytics.enabled = false;
            Debug.Log("[Analytics] consent revoked — events stopped");
        }

        /// <summary>
        /// The one door: every event in the game goes through here.
        /// Blocked silently (with a log) until consent is granted.
        /// </summary>
        public static void Track(string name, Dictionary<string, object> data)
        {
            if (!consented)
            {
                Debug.LogWarning("[Analytics] Track('" + name + "') blocked — no consent yet");
                return;
            }
            Analytics.CustomEvent(name, data);
        }

        /// <summary>Convenience overload for single-value events.</summary>
        public static void Track(string name, string key, object value)
        {
            Track(name, new Dictionary<string, object> { { key, value } });
        }
    }
}
