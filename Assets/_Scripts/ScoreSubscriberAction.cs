/// <summary>
/// Subscriber for Action -- subscribe in code
/// </summary>

using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class ScoreSubscriberAction : MonoBehaviour
    {
        private void OnEnable()
        {
            // Subscribe when the object wakes
            var publisher = GetComponent<ScorePublisherAction>();
            publisher.OnScoreIncreased += UpdateScore;
        }

        private void OnDisable()
        {
            // Unsubscribe when the object sleeps
            var publisher = GetComponent<ScorePublisherAction>();
            publisher.OnScoreIncreased -= UpdateScore;
        }

        public void UpdateScore(int score)
        {
            Debug.Log($"[Subscriber-Action] Score is now: {score}");
        }
    }
}
