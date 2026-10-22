using System;
using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class SeededRandomExample : MonoBehaviour
    {
        [SerializeField] private int seed = 12345;
        [SerializeField] private int numberCount = 10;
        [SerializeField] private int minValue = 0;
        [SerializeField] private int maxValue = 100;

        [ContextMenu("Generate Random Numbers")]
        public void GenerateRandomNumbers()
        {
            if (numberCount < 1 || maxValue <= minValue)
            {
                Debug.LogError("Set a positive number count and a max value greater than min value.", this);
                return;
            }

            var random = new System.Random(seed);

            for (int i = 0; i < numberCount; i++)
            {
                Debug.Log(random.Next(minValue, maxValue), this);
            }
        }
    }
}