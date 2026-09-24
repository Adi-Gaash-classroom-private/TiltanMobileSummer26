/// <summary>
/// Approach 3: SO Bus (GameEvents asset)
/// </summary>

using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class ScorePublisherBus : MonoBehaviour
    {
        public void Fire()
        {
            // Access the bus through the singleton accessor
            var bus = GameManagerAccessor.Instance.Events;
            bus.OnScoreChanged?.Invoke(10);
            Debug.Log("[SO Bus] Score increased by 10");
        }
    }
}
