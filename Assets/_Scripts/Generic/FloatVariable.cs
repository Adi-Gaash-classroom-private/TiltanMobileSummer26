using UnityEngine;

namespace TiltanMobileSummer2026.Generic
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Variables/Float Variable")]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField] private float value;

        public float Value
        {
            get => value;
            set => this.value = value;
        }
    }
}