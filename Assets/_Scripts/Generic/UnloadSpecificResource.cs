using UnityEngine;

namespace TiltanMobileSummer2026._Scripts.Generic
{
    public class ResourceUnloader : MonoBehaviour
    {
        [Tooltip("Assign the asset (Texture, AudioClip, Mesh, Material, etc.) in the Inspector.")]
        public Object assetToUnload;

        public void UnloadAssignedResource()
        {
            if (assetToUnload != null)
            {
                Resources.UnloadAsset(assetToUnload);
                Debug.Log($"Successfully unloaded {assetToUnload.name} from memory.");
                assetToUnload = null;
            }
            else
            {
                Debug.LogWarning("No asset assigned to unload.");
            }
        }
    }
}