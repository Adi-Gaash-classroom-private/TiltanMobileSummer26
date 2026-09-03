using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class VisualOrganizationExample : MonoBehaviour
    {
        [Header("Combat Parameters")]
        [Tooltip("Controls bullet spread angle in degrees.")]
        [SerializeField] private float bulletSpread = 5f;

        [Space(10)]

        [Header("Movement Parameters")]
        [Tooltip("Defines maximum movement speed.")]
        [SerializeField] private float moveSpeed = 10f;
    }
}