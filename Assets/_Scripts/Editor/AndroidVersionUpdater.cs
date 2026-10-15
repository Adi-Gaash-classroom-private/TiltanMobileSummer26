using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace TiltanMobileSummer2026._Scripts.Editor
{
    public class AndroidVersionUpdater : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            if (report.summary.platform == BuildTarget.Android)
            {
                PlayerSettings.Android.bundleVersionCode += 1;

                string currentVersion = PlayerSettings.bundleVersion;
                string newVersion = IncrementLastDigit(currentVersion);
            
                PlayerSettings.bundleVersion = newVersion;

                Debug.Log($"Updated Android Bundle Version Code to: {PlayerSettings.Android.bundleVersionCode}");
                Debug.Log($"Updated Version String to: {PlayerSettings.bundleVersion}");
            }
        }

        private string IncrementLastDigit(string version)
        {
            if (string.IsNullOrEmpty(version))
            {
                return "1.0.1";
            }

            string[] parts = version.Split('.');
            if (parts.Length > 0)
            {
                int lastIndex = parts.Length - 1;
                if (int.TryParse(parts[lastIndex], out int lastNumber))
                {
                    parts[lastIndex] = (lastNumber + 1).ToString();
                    return string.Join(".", parts);
                }
            }

            return version + ".1";
        }
    }
}