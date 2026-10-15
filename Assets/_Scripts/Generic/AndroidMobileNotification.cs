using System.Collections;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;

namespace TiltanMobileSummer2026._Scripts.Generic
{
    public class AndroidMobileNotification : MonoBehaviour
    {
        private const string ChannelId = "default_channel";
        private const string ChannelName = "Default Channel";
        
#if UNITY_ANDROID

        public void ScheduleNotification(string title, string message, int delayInSeconds)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                StartCoroutine(ScheduleNotificationRoutine(title, message, delayInSeconds));
            }
            else
            {
                Debug.LogWarning("Notifications are only supported on Android.");
            }
        }

        public void RemoveAllNotifications()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                AndroidNotificationCenter.CancelAllNotifications();
            }
        }

        private IEnumerator ScheduleNotificationRoutine(string title, string message, int delayInSeconds)
        {
            if (AndroidNotificationCenter.UserPermissionToPost != PermissionStatus.Allowed)
            {
                var request = new PermissionRequest();
                while (request.Status == PermissionStatus.RequestPending)
                {
                    yield return null;
                }

                if (AndroidNotificationCenter.UserPermissionToPost != PermissionStatus.Allowed)
                {
                    yield break;
                }
            }

            var importance = Importance.Default;
            var channel = new AndroidNotificationChannel(ChannelId, ChannelName, "Generic notifications", importance);
            AndroidNotificationCenter.RegisterNotificationChannel(channel);

            var notification = new AndroidNotification
            {
                Title = title,
                Text = message,
                FireTime = System.DateTime.Now.AddSeconds(delayInSeconds)
            };

            AndroidNotificationCenter.SendNotification(notification, ChannelId);
        }
#endif
    }
}