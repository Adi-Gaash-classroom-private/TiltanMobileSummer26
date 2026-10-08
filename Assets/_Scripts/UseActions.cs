using System;

namespace TiltanMobileSummer2026
{
    public class UseActions
    {
        public void ActionTrigger(int newScore)
        {
            
            //ProtectedActions.ScoreChangedEvent?.Invoke(newScore); //events can only be invoked from within the class that defines them, so this line will cause a compilation error
            //ProtectedActions.ScoreChangedEvent = null; // events can only null from within the class that defines them, so this line will cause a compilation error
            ProtectedEvents.ScoreChangedEvent -= WhenScoreChanged;
            
            //Actions.ScoreChangedEvent = null; // same as above, events can only be null from within the class that defines them, so this line will cause a compilation error
            //Actions.ScoreChangedEvent?.Invoke(newScore);
            
            Actions.OnScoreChanged?.Invoke(newScore);
            Actions.OnScoreChanged = null;
            Actions.ScoreChangedEvent += WhenScoreChanged;
            ActionsWithUnityActions.OnScoreChangedUnityActions?.Invoke(newScore);
            ActionsWithUnityActions.OnScoreChangedUnityActions = null;
            ActionsWithUnityActions.OnScoreChangedUnityActions += WhenScoreChanged;
            
            
            EventsWithUnityEvents.OnScoreChangedUnityEvents?.Invoke(newScore);
            EventsWithUnityEvents.OnScoreChangedUnityEvents = null;
            EventsWithUnityEvents.OnScoreChangedUnityEvents.AddListener(WhenScoreChanged);
            EventsWithUnityEvents.OnScoreChangedUnityEvents.RemoveListener(WhenScoreChanged);
            EventsWithUnityEvents.OnScoreChangedUnityEvents.RemoveAllListeners();

        }
        
        void WhenScoreChanged(int newScore)
        {
            // Handle the score change event
            Console.WriteLine($"Score changed to: {newScore}");
        }
        
        
    }
}