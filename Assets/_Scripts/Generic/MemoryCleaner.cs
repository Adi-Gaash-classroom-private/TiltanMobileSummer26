using UnityEngine;

namespace TiltanMobileSummer2026._Scripts.Generic
{
    public class MemoryCleaner: MonoBehaviour
    {
        public static void ClearMemory()
        {
            // Unload unused assets
            Resources.UnloadUnusedAssets();

            // Force garbage collection
            System.GC.Collect();
        }
        
    }
}