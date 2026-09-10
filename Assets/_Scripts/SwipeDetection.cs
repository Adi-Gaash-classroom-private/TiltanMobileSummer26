using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using InputSystemTouchPhase = UnityEngine.InputSystem.TouchPhase;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float minSwipeDistance = 50f;
    [SerializeField] private float maxSwipeTime = 0.5f;

    private Vector2 startPosition;
    private float startTime;
    private int trackedTouchId = -1;

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
            if (touch.phase == InputSystemTouchPhase.Began && trackedTouchId == -1)
            {
                trackedTouchId = touch.touchId;
                startPosition = touch.screenPosition;
                startTime = Time.time;
            }
            else if (touch.touchId == trackedTouchId)
            {
                if (touch.phase == InputSystemTouchPhase.Ended || touch.phase == InputSystemTouchPhase.Canceled)
                {
                    DetectSwipe(touch.screenPosition);
                    trackedTouchId = -1;
                }
            }
        }
    }

    private void DetectSwipe(Vector2 endPosition)
    {
        float distance = Vector2.Distance(startPosition, endPosition);
        float duration = Time.time - startTime;

        if (distance >= minSwipeDistance && duration <= maxSwipeTime)
        {
            Vector2 direction = endPosition - startPosition;
            Vector2 normalizedDirection = direction.normalized;

            if (Mathf.Abs(normalizedDirection.x) > Mathf.Abs(normalizedDirection.y))
            {
                if (normalizedDirection.x > 0)
                    Debug.Log("Swipe Right");
                else
                    Debug.Log("Swipe Left");
            }
            else
            {
                if (normalizedDirection.y > 0)
                    Debug.Log("Swipe Up");
                else
                    Debug.Log("Swipe Down");
            }
        }
    }
}