using UnityEngine;
using UnityEngine.Playables;

namespace TiltanMobileSummer2026
{
    public class MyPlayableBehaviour : PlayableBehaviour
    {
        // Serialized values passed from the Asset
        public float Duration = 5.0f;
        public float Amplitude = 1.0f;

        // Called when the PlayableGraph starts playing
        public override void OnGraphStart(Playable playable)
        {
            Debug.Log("Playable graph started");
        }

        // Called when the PlayableGraph stops playing
        public override void OnGraphStop(Playable playable)
        {
            Debug.Log("Playable graph stopped");
        }

        // Called when this specific playable starts playing
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            // Reset state or initialize per-playable logic
        }

        // Called when this specific playable is paused or stopped
        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            // Clean up per-playable state
        }

        // Main execution loop (called every frame the graph is playing)
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            // 'playerData' is typically a Transform reference passed during graph creation
            // If you don't pass playerData, it will be null
        
            // Example: Apply logic based on time or configuration
            // float normalizedTime = playable.GetTime() / Duration;
        }
    }
}