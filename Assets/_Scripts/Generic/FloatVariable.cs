using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TiltanMobileSummer2026.Generic
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Variables/Float Variable")]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField] private float value;
        [SerializeField] private float initValue;

        public System.Action<float> OnValueChanged;

        public float Value
        {
            get => value;
            set
            {
                if (!this.value.Equals(value))
                {
                    this.value = value;
                    OnValueChanged?.Invoke(this.value);
                }
            }
        }

        public float InitValue
        {
            get => initValue;
            set => initValue = value;
        }

#if UNITY_EDITOR
        private void OnEnable()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private void OnDisable()
        {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        }

        private void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            // When exiting play mode in the editor, reset the variable to the initialization value.
            if (state == PlayModeStateChange.ExitingPlayMode)
            {
                Value = initValue;
            }
        }
#endif
    }
}