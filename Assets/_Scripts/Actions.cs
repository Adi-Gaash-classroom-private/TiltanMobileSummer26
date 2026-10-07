using System;
using UnityEngine;
using UnityEngine.Events;

namespace TiltanMobileSummer2026
{
    public class ProtectedActions
    {
        public delegate void ScoreChanged(int newScore);
        
        public static event ScoreChanged ScoreChangedEvent;
        
        
        void WhenScoreChanged(int newScore)
        {
            // Handle the score change event
            Console.WriteLine($"Score changed to: {newScore}");
        }
        
        void Start()
        {
            ScoreChanged myScoreChanged = WhenScoreChanged;
            
            ScoreChangedEvent.Invoke(10); // Example usage
            
            ScoreChangedEvent = null;
        }
    }
    
    public class Actions
    {
        public static Action<int> OnScoreChanged;
        public static event Action<int> ScoreChangedEvent;

        public void ChangeScore(int newScore)
        {
            // Trigger the event when the score changes
            OnScoreChanged?.Invoke(newScore);
            ScoreChangedEvent?.Invoke(newScore);
        }
    }

    // same as Actions but using UnityAction instead of Action - use UnityAction when you want to use Unity's serialization system and inspector support
    public class ActionsWithUnityActions
    {
        
        public static UnityAction<int> OnScoreChangedUnityActions;
        
        public void ChangeScore(int newScore)
        {
            // Trigger the event when the score changes
            OnScoreChangedUnityActions?.Invoke(newScore);
            
        }
    }
    // same as ActionsWithUnityActions but using UnityEvent instead of UnityAction
    // use UnityEvent when you want to use Unity's serialization system and inspector support, and you want to be able to assign event listeners in the Unity Editor
    public class EventsWithUnityEvents
    {
        public static UnityEvent<int> OnScoreChangedUnityEvents;
        
        public void ChangeScore(int newScore)
        {
            // Trigger the event when the score changes
            OnScoreChangedUnityEvents?.Invoke(newScore);
            
        }
    }
}