using System;
using UnityEngine;

namespace TiltanMobileSummer2026
{
    /// <summary>
    /// Consent gate: returns to a remembered decision for repeat players,
    /// and exposes ConsentDecided for the UI to hide its panel.
    /// </summary>
    public class ConsentGate : MonoBehaviour
    {
        const string PREF_KEY = "analytics_consent";

        /// <summary>Raised after Decide() so UI can close its panel.</summary>
        public event Action<bool> ConsentDecided;

        void OnEnable()
        {
            int saved = PlayerPrefs.GetInt(PREF_KEY, 0);
            if (saved == 1)
            {
                // Returning player — already asked once, honor the choice.
                AnalyticsManager.GrantConsent();
            }
            // First run: the UI shows the consent panel and its
            // buttons call Decide(true) / Decide(false).
        }

        /// <summary>Call from the "I agree" / "No thanks" buttons.</summary>
        public void Decide(bool agreed)
        {
            PlayerPrefs.SetInt(PREF_KEY, agreed ? 1 : 0);
            if (agreed)
            {
                AnalyticsManager.GrantConsent();
            }
            else
            {
                AnalyticsManager.RevokeConsent();
            }
            if (ConsentDecided != null)
            {
                ConsentDecided.Invoke(agreed);
            }
        }
    }
}
