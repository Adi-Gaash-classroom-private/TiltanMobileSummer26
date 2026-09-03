using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#endif

namespace TiltanMobileSummer2026
{
    [CreateAssetMenu(fileName = "MyEditorSetup", menuName = "Settings/My Editor Setup")]
    public class MyEditorSetup : ScriptableObject
    {
        public string exampleSetting = "default";

#if UNITY_EDITOR
        private const string DefaultAssetPath = "Assets/Settings/MyEditorSetup.asset";
        private static MyEditorSetup instance;

        public static MyEditorSetup Instance
        {
            get
            {
                if (instance == null)
                    instance = LoadOrCreateAsset();
                return instance;
            }
        }

        private static MyEditorSetup LoadOrCreateAsset()
        {
            // find existing
            var guids = AssetDatabase.FindAssets("t:MyEditorSetup");
            if (guids.Length > 0)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[0]);
                var existing = AssetDatabase.LoadAssetAtPath<MyEditorSetup>(path);
                if (existing != null)
                {
                    if (guids.Length > 1)
                        Debug.LogWarning("Multiple MyEditorSetup assets found. Using first: " + path);
                    return existing;
                }
            }

            // ensure folder exists
            EnsureFolderExists(Path.GetDirectoryName(DefaultAssetPath).Replace("\\", "/"));

            // create new
            var asset = CreateInstance<MyEditorSetup>();
            AssetDatabase.CreateAsset(asset, DefaultAssetPath);
            AssetDatabase.SaveAssets();
            Debug.Log("Created MyEditorSetup at " + DefaultAssetPath);
            return asset;
        }

        private static void EnsureFolderExists(string folderPath)
        {
            if (AssetDatabase.IsValidFolder(folderPath)) return;
            var parts = folderPath.Split('/');
            string current = parts[0]; // "Assets"
            for (int i = 1; i < parts.Length; i++)
            {
                string next = current + "/" + parts[i];
                if (!AssetDatabase.IsValidFolder(next))
                    AssetDatabase.CreateFolder(current, parts[i]);
                current = next;
            }
        }
#endif
    }
}