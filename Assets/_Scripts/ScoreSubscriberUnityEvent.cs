/// <summary>
/// Subscriber for UnityEvent -- wired in the Inspector
/// </summary>

using UnityEngine;

namespace TiltanMobileSummer2026
{
    // Drag this component's UpdateScore method onto the event slot
    // in the Inspector (ScorePublisherUnityEvent.OnScoreIncreased)
    public class ScoreSubscriberUnityEvent : MonoBehaviour
    {
        public void UpdateScore(int score)
        {
            Debug.Log($"[Subscriber-UnityEvent] Score is now: {score}");
        }
    }
}
