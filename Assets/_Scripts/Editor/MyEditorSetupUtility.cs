#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace TiltanMobileSummer2026._Scripts.Editor
{
    public static class MyEditorSetupUtility
    {
        // Adds a menu item to the Unity top menu bar under "Tools > My Editor Setup > Select or Create".
        [MenuItem("Tools/My Editor Setup/Select or Create")]
        public static void SelectOrCreate()
        {
            // Retrieves the singleton instance of the MyEditorSetup configuration asset.
            var asset = MyEditorSetup.Instance;

            // Sets the specified object as the active selection in the Unity Editor (visible in the Inspector).
            Selection.activeObject = asset;
        
            // Visually highlights and flashes the specified asset object in the Project window.
            EditorGUIUtility.PingObject(asset);
        }

        // Executes automatically upon editor startup and after assembly recompilation.
        [InitializeOnLoadMethod]
        static void CheckDuplicates()
        {
            // Delays execution until the editor is fully loaded and safe to query the asset database.
            EditorApplication.delayCall += () =>
            {
                // Searches the asset database for all assets matching the filter type "t:MyEditorSetup".
                var guids = AssetDatabase.FindAssets("t:MyEditorSetup");
            
                // Logs a warning to the Unity Console if more than one configuration asset instance exists.
                if (guids.Length > 1)
                    Debug.LogWarning("Multiple MyEditorSetup assets found. Keep only one to ensure unique settings.");
            };
        }
    }
}
#endif