/// <summary>
/// Approach 1: UnityEvent (declare + Inspector wire)
/// </summary>

using UnityEngine;
using UnityEngine.Events;

namespace TiltanMobileSummer2026
{
    public class ScorePublisherUnityEvent : MonoBehaviour
    {
        // Declare the event field -- wire subscribers in the Inspector
        public UnityEvent<int> OnScoreIncreased;

        public void Fire()
        {
            // Null-conditional operator is non-negotiable
            OnScoreIncreased?.Invoke(10);
            Debug.Log("[UnityEvent] Score increased by 10");
        }
    }
}
