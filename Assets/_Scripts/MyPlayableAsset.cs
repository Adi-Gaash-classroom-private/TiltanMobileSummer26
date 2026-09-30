using UnityEngine;
using UnityEngine.Playables;

namespace TiltanMobileSummer2026
{
    [System.Serializable]
    public class MyPlayableAsset : PlayableAsset
    {
        [Tooltip("Configuration values for this playable")]
        public float Duration = 5.0f;
        public float Amplitude = 1.0f;

        // This method is called when the PlayableGraph is created
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            // Create the ScriptPlayable instance
            var playable = ScriptPlayable<MyPlayableBehaviour>.Create(graph);
        
            // Get the behaviour instance and assign serialized data
            var behaviour = playable.GetBehaviour();
            behaviour.Duration = Duration;
            behaviour.Amplitude = Amplitude;
        
            return playable;
        }
    }
}