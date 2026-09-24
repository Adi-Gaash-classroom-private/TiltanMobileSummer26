/// <summary>
/// Approach 2: Action/Delegate (code-only)
/// </summary>

using System;
using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class ScorePublisherAction : MonoBehaviour
    {
        // Declare the event field -- subscribe in code
        public Action<int> OnScoreIncreased;

        public void Fire()
        {
            // Null-conditional operator is non-negotiable
            OnScoreIncreased?.Invoke(10);
            Debug.Log("[Action] Score increased by 10");
        }
    }
}
