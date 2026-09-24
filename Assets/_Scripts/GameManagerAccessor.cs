/// <summary>
/// GameManagerAccessor -- singleton that carries the GameEvents bus
/// (Same pattern as Stage 02 -- the L01 singleton with a bus)
/// </summary>

using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class GameManagerAccessor : MonoBehaviour
    {
        public static GameManagerAccessor Instance { get; private set; }

        public GameEventsSO Events;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            // Fallback: create the SO asset in code if not assigned
            if (Events == null)
            {
                Events = ScriptableObject.CreateInstance<GameEventsSO>();
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}
