using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace TiltanMobileSummer2026
{
    public class EnhancedTouch : MonoBehaviour
    {
        private void OnEnable()
        {
            EnhancedTouchSupport.Enable();
        }

        private void OnDisable()
        {
            EnhancedTouchSupport.Disable();
        }

        private void Update()
        {
            foreach (var touch in Touch.activeTouches)
            {
                Debug.Log($"Touch ID: {touch.touchId}, Position: {touch.screenPosition}, Phase: {touch.phase}");
                
            }
        }
    }
}