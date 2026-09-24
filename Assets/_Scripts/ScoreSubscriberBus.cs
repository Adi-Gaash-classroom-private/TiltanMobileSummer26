/// <summary>
/// Subscriber for SO Bus -- subscribes through the bus
/// </summary>

using UnityEngine;


namespace TiltanMobileSummer2026
{
    public class ScoreSubscriberBus : MonoBehaviour
    {
        private void OnEnable()
        {
            var bus = GameManagerAccessor.Instance.Events;
            bus.OnScoreChanged += UpdateScore;
        }

        private void OnDisable()
        {
            var bus = GameManagerAccessor.Instance.Events;
            bus.OnScoreChanged -= UpdateScore;
        }

        public void UpdateScore(int score)
        {
            Debug.Log($"[Subscriber-Bus] Score is now: {score}");
        }
    }
}
