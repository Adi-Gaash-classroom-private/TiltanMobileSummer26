using UnityEngine;

namespace TiltanMobileSummer2026
{
    [ExecuteAlways]
    public class LerpVsSlerpDemo : MonoBehaviour
    {
        [Header("Path Configuration")] public Transform startTransform;
        public Transform endTransform;

        [Header("Midpoint")] public Transform midpointTransform;

        [Header("Progress Control")] [Range(0f, 1f)]
        public float progressPercent = 0.5f;

        public bool animateProgress = false;
        [Range(0.1f, 5f)] public float animationSpeed = 1f;

        [Header("Visual Markers")] public Transform lerpMarker;
        public Transform slerpMarker;

      

        private void Update()
        {
            if (animateProgress)
            {
                progressPercent += animationSpeed * Time.deltaTime;
                if (progressPercent > 1f) progressPercent = 0f;
            }

            UpdateVisualization();
            UpdateMidpoint();
        }

        // Ensures the midpoint updates instantly in the Editor when transforms are changed in the Inspector
        private void OnValidate()
        {
            UpdateMidpoint();
        }

        private void UpdateVisualization()
        {
            if (startTransform == null || endTransform == null) return;

            Vector3 startPos = startTransform.position;
            Vector3 endPos = endTransform.position;

            Vector3 lerpPos = Vector3.Lerp(startPos, endPos, progressPercent);
            Vector3 slerpPos = Vector3.Slerp(startPos, endPos, progressPercent);

            if (lerpMarker != null) lerpMarker.position = lerpPos;
            if (slerpMarker != null) slerpMarker.position = slerpPos;
        }

        private void UpdateMidpoint()
        {
            if (startTransform == null || endTransform == null) return;

            // Calculate exact halfway position
            Vector3 midpointPos = (startTransform.position + endTransform.position) * 0.5f;

            if (midpointTransform != null)
            {
                midpointTransform.position = midpointPos;
            }
        }
    }
}