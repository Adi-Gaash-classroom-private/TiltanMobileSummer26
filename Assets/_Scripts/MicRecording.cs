using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class MicRecording : MonoBehaviour
    {
        private AudioSource _audioSource;
        private string _microphoneDevice;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void StartRecording()
        {
            if (Microphone.devices.Length == 0)
            {
                return;
            }

            _microphoneDevice = Microphone.devices[0];
            _audioSource.clip = Microphone.Start(_microphoneDevice, false, 10, 44100);
        }

        public void StopRecording()
        {
            if (string.IsNullOrEmpty(_microphoneDevice) || !Microphone.IsRecording(_microphoneDevice))
            {
                return;
            }

            Microphone.End(_microphoneDevice);
        }

        public void PlayRecording()
        {
            if (_audioSource.clip != null && !Microphone.IsRecording(_microphoneDevice))
            {
                _audioSource.Play();
            }
        }
    }
}