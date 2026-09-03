using TiltanMobileSummer2026.Generic;
using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class FloatVariableListener : MonoBehaviour
    {
        [SerializeField] private FloatVariable floatVariable;

        private void OnEnable()
        {
            if (floatVariable != null)
            {
                floatVariable.OnValueChanged += HandleValueChanged;
            }
        }

        private void OnDisable()
        {
            if (floatVariable != null)
            {
                floatVariable.OnValueChanged -= HandleValueChanged;
            }
        }

        private void HandleValueChanged(float newValue)
        {
            Debug.Log($"Float Variable changed to: {newValue}");
        }
    }
}