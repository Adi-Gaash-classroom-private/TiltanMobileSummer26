using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class BoundaryEnforcementExample : MonoBehaviour
    {
        [Range(0.1f, 10f)]
        [SerializeField] private float speed = 5f;

        [TextArea(3, 10)]
        [SerializeField] private string itemDescription = "Enter description here...";
    }
}