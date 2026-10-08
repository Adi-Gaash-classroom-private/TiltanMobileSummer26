using System.Threading.Tasks;
using UnityEngine;

namespace TiltanMobileSummer2026
{
    
    public class TaskExample : MonoBehaviour
    {
        private async void Start()
        {
            // 1. Executing CPU-bound work on a background thread pool using Task.Run
            // This prevents freezing the Unity main thread during heavy calculations.
            Debug.Log("Starting background task...");
            int result = await Task.Run(() => HeavyComputation());
            Debug.Log($"Background task completed with result: {result}");

            // 2. Delaying execution asynchronously using Task.Delay
            Debug.Log("Waiting for 2 seconds...");
            await Task.Delay(2000);
            Debug.Log("2 seconds elapsed.");
        }

        private int HeavyComputation()
        {
            int sum = 0;
            for (int i = 0; i < 1000000; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
    
}