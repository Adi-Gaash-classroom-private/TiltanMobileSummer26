using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

namespace TiltanMobileSummer2026
{
    public class SequentialPermissionManager : MonoBehaviour
    {
        private readonly List<string> _permissionsToRequest = new List<string>()
        {
#if PLATFORM_ANDROID
            Permission.Camera,
            Permission.Microphone
#endif
        };

        private bool _isProcessing = false;

        private void Start()
        {
            CheckAndRequestPermissions();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus && !_isProcessing)
            {
                CheckAndRequestPermissions();
            }
        }

        public void CheckAndRequestPermissions()
        {
#if PLATFORM_ANDROID
            if (!_isProcessing)
            {
                StartCoroutine(ProcessPermissionsSequentially());
            }
#endif
        }

        private IEnumerator ProcessPermissionsSequentially()
        {
            _isProcessing = true;

#if PLATFORM_ANDROID
            foreach (string permission in _permissionsToRequest)
            {
                if (!Permission.HasUserAuthorizedPermission(permission))
                {
                    bool isGranted = false;
                    bool isDenied = false;

                    PermissionCallbacks callbacks = new PermissionCallbacks();
                    callbacks.PermissionGranted += (permName) => isGranted = true;
                    callbacks.PermissionDenied += (permName) => isDenied = true;
                    callbacks.PermissionDeniedAndDontAskAgain += (permName) => isDenied = true;

                    Permission.RequestUserPermission(permission, callbacks);

                    yield return new WaitUntil(() => isGranted || isDenied);
                }
            }
#endif

            _isProcessing = false;
        }
    }
}