using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class BasicWebcam: MonoBehaviour
    {
        private WebCamTexture webcamTexture;

        void Start()
        {
            WebCamDevice[] devices = WebCamTexture.devices;

            if (devices.Length == 0)
            {
                Debug.LogError("No webcam devices found.");
                return;
            }

            // Initialize the first available webcam at 1280x720, 30 FPS
            webcamTexture = new WebCamTexture(devices[0].name, 1280, 720, 30);

            Renderer camRenderer = GetComponent<Renderer>();
            if (camRenderer != null)
            {
                camRenderer.material.mainTexture = webcamTexture;
            }

            webcamTexture.Play();
        }

        void OnDisable()
        {
            if (webcamTexture != null && webcamTexture.isPlaying)
            {
                webcamTexture.Stop();
            }
        }
    }
}