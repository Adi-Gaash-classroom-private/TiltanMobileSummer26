using System;
using UnityEngine;

namespace TiltanMobileSummer2026
{
    [CreateAssetMenu(fileName = "GeneralSettings", menuName = "Game Settings/General Settings", order = 0)]
    public class GeneralSettingSO : ScriptableObject
    {
        public float playerSpeed = 5f;
        public float playerJumpForce = 10f;


        private void OnValidate()
        {
            if (playerSpeed < 0f)
            {
                Debug.LogWarning("Player speed cannot be negative. Resetting to default value of 5.");
                playerSpeed = 5f;
            }
            if (playerJumpForce < 0f)
            {
                Debug.LogWarning("Player jump force cannot be negative. Resetting to default value of 10.");
                playerJumpForce = 10f;
            }
        }
    }
}