using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TiltanMobileSummer2026._Scripts.Generic
{
    public class LoadAssetIntoMemory : MonoBehaviour
    {
        public string assetKey;

        // Holds a reference to the loaded asset
        private GameObject loadedPrefab;
        private AsyncOperationHandle<GameObject> loadHandle;

        void Start()
        {
            PreloadAsset();
        }

        void PreloadAsset()
        {
            // Starts downloading/loading the asset into memory without placing it in the scene
            loadHandle = Addressables.LoadAssetAsync<GameObject>(assetKey);
            loadHandle.Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    loadedPrefab = handle.Result;
                    Debug.Log($"Successfully preloaded: {assetKey} into memory.");
                }
                else
                {
                    Debug.LogError($"Failed to preload asset: {assetKey}");
                }
            };
        }

        // Call this method whenever you actually want to spawn it
        public void SpawnLoadedAsset()
        {
            if (loadedPrefab != null)
            {
                Instantiate(loadedPrefab);
                Debug.Log("Spawned preloaded asset into the scene.");
            }
            else
            {
                Debug.LogWarning("Asset is not loaded yet!");
            }
        }

        // Important: Release memory when you are completely done with the asset
        void OnDestroy()
        {
            if (loadHandle.IsValid())
            {
                Addressables.Release(loadHandle);
            }
        }
    }

}