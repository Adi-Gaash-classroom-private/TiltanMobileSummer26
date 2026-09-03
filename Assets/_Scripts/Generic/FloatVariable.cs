using UnityEngine;

namespace TiltanMobileSummer2026.Generic
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Variables/Float Variable")]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField] private float value;

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
    }
}