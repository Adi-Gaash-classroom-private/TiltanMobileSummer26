using UnityEngine;

namespace TiltanMobileSummer2026._Scripts.Generic
{
    public class LoadFromResources : MonoBehaviour
    {
        [Tooltip("Path relative to any Resources folder, without the file extension.")]
        public string resourcePath;

        void Start()
        {
            LoadAsset();
        }

        void LoadAsset()
        {
            // Example path format: "Prefabs/MyAsset"
            GameObject loadedPrefab = Resources.Load<GameObject>(resourcePath);

            if (loadedPrefab != null)
            {
                Instantiate(loadedPrefab);
                Debug.Log($"Successfully loaded and instantiated {resourcePath} from Resources folder.");
            }
            else
            {
                Debug.LogError($"Failed to load asset at path: {resourcePath}");
            }
        }
    }
}