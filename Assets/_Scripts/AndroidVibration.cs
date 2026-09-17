namespace TiltanMobileSummer2026
{
    using UnityEngine;

    public class AndroidVibration : MonoBehaviour
    {
        // Simple short vibration
        public static void Vibrate(long milliseconds = 250)
        {
            if (Application.platform != RuntimePlatform.Android) return;

            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            using (AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator"))
            {
                if (vibrator == null || !vibrator.Call<bool>("hasVibrator")) return;

                using (AndroidJavaClass buildVersion = new AndroidJavaClass("android.os.Build$VERSION"))
                {
                    int sdkInt = buildVersion.GetStatic<int>("SDK_INT");

                    if (sdkInt >= 26) // Android 8.0 (API 26) and above
                    {
                        using (AndroidJavaClass vibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect"))
                        {
                            int defaultAmplitude = vibrationEffectClass.GetStatic<int>("DEFAULT_AMPLITUDE");
                            using (AndroidJavaObject effect = vibrationEffectClass.CallStatic<AndroidJavaObject>("createOneShot", milliseconds, defaultAmplitude))
                            {
                                vibrator.Call("vibrate", effect);
                            }
                        }
                    }
                    else // Deprecated fallback for Android 7.1 and below
                    {
                        vibrator.Call("vibrate", milliseconds);
                    }
                }
            }
        }

        // Pattern vibration: timings (ms) and amplitudes (0-255)
        public static void VibratePattern(long[] timings, int[] amplitudes, int repeat = -1)
        {
            if (Application.platform != RuntimePlatform.Android) return;

            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            using (AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator"))
            {
                if (vibrator == null || !vibrator.Call<bool>("hasVibrator")) return;

                using (AndroidJavaClass buildVersion = new AndroidJavaClass("android.os.Build$VERSION"))
                {
                    int sdkInt = buildVersion.GetStatic<int>("SDK_INT");

                    if (sdkInt >= 26)
                    {
                        using (AndroidJavaClass vibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect"))
                        using (AndroidJavaObject effect = vibrationEffectClass.CallStatic<AndroidJavaObject>("createWaveform", timings, amplitudes, repeat))
                        {
                            vibrator.Call("vibrate", effect);
                        }
                    }
                    else
                    {
                        vibrator.Call("vibrate", timings, repeat);
                    }
                }
            }
        }
    }
}