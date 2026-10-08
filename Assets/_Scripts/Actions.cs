using System;
using UnityEngine;
using UnityEngine.Events;

namespace TiltanMobileSummer2026
{
    public class ProtectedEvents
    {
        // Define a delegate for the score change event - delegates are like function pointers, they define the signature of the method that can be called when the event is triggered
        // Because this is a delegate, it can be used to define an event, that can only be controlled from within this class, and not from outside of it!
        
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