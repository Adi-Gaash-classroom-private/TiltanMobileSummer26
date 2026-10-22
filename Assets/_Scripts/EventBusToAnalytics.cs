
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TiltanMobileSummer2026
{
    /// <summary>
    /// Listens to your existing UnityEvent bus and re-fires the
    /// same moments into analytics. Zero game-code changes.
    /// </summary>
    public class EventBusToAnalytics : MonoBehaviour
    {
        [SerializeField] UnityEvent onPlayerDied; // your L06 bus field
        [SerializeField] UnityEvent onPurchase;   // optional

        void OnEnable()
        {
            if (onPlayerDied != null)
            {
                onPlayerDied.AddListener(PlayerDied);
            }
            if (onPurchase != null)
            {
                onPurchase.AddListener(Purchased);
            }
        }

        void OnDisable()
        {
            if (onPlayerDied != null)
            {
                onPlayerDied.RemoveListener(PlayerDied);
            }
            if (onPurchase != null)
            {
                onPurchase.RemoveListener(Purchased);
            }
        }

        void PlayerDied()
        {
            var data = new Dictionary<string, object>
            {
                { AnalyticsEvents.KEY_SCORE,    GameStats.Score },
                { AnalyticsEvents.KEY_ATTEMPTS, GameStats.Attempts },
            };
            AnalyticsManager.Track(AnalyticsEvents.GAME_OVER, data);
        }

        void Purchased()
        {
            var data = new Dictionary<string, object>
            {
                { AnalyticsEvents.KEY_ITEM_ID, GameStats.LastPurchaseId },
                { AnalyticsEvents.KEY_PRICE,   GameStats.LastPurchasePrice },
            };
            AnalyticsManager.Track(AnalyticsEvents.PURCHASE, data);
        }
    }
}
