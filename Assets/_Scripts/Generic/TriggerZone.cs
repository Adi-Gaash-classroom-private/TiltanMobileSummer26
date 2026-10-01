using UnityEngine;
using UnityEngine.Events;

namespace TiltanMobileSummer2026
{
    public class TriggerZone : MonoBehaviour
    {
        // 1. Define the UnityEvent
        public UnityEvent onTriggered = new UnityEvent();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // 2. Invoke (fire) the event when the condition is met
                onTriggered?.Invoke();
            }
        }
    }
}