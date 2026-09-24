/// <summary>
/// GameEventsSO -- the shared event bus (ScriptableObject)
/// </summary>

using System;
using UnityEngine;
using UnityEngine.Events;

namespace TiltanMobileSummer2026
{
    [CreateAssetMenu(fileName = "GameEvents", menuName = "L06/GameEvents")]
    public class GameEventsSO : ScriptableObject
    {
        public Action<int> OnScoreChanged;
        public UnityEvent OnPlayerDeath;
        public Action<float> OnHealthChanged;
    }
}
