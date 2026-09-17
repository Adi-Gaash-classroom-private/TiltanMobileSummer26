using UnityEngine;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

namespace TiltanMobileSummer2026
{
    public class SimpleMicrophonePermission : MonoBehaviour
    {
        private void Start()
        {
            RequestMicrophonePermission();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
            {
                RequestMicrophonePermission();
            }
        }

        public void RequestMicrophonePermission()
        {
#if PLATFORM_ANDROID
            if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
            {
                Permission.RequestUserPermission(Permission.Microphone);
            }
#endif
        }
    }
}