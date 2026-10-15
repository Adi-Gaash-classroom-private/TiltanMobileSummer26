using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TiltanMobileSummer2026._Scripts.Generic
{
    public class RemoteAssetLoader : MonoBehaviour
    {
        [Tooltip("The address name of the asset assigned in your Addressables groups.")]
        public string assetKey;
        public Transform parentTransform;

        void Start()
        {
            Addressables.InstantiateAsync(assetKey, parentTransform).Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    Debug.Log("Asset instantiated successfully under parent.");
                }
                else
                {
                    Debug.LogError("Failed to instantiate asset.");
                }
            };
        }
    }
}
