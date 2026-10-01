using System;
using DG.Tweening;
using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class WeaponRecoilCam : MonoBehaviour
    {
        private Camera mainCamera;
        [SerializeField] private float normalFOV = 60f;
        [SerializeField] private float zoomFOV = 40f;
        [SerializeField] private float weaponRecoilStrength = 1f;

        private void Start()
        {
            mainCamera = GetComponent<Camera>();
        }

        public void FireRecoil(float strength)
        {
            // Shake position without creating or managing animation assets
            mainCamera.transform.DOShakePosition(0.15f, strength * 0.2f, 20, 90f, false, true);
        
            // Shake rotation for realistic kick
            mainCamera.transform.DOShakeRotation(0.15f, new Vector3(strength, strength * 0.5f, 0f));
        }

        public void SetAimDownSights(bool isAiming)
        {
            mainCamera.DOKill();
            float targetFOV = isAiming ? zoomFOV : normalFOV;
        
            // Smoothly interpolate FOV dynamically
            mainCamera.DOFieldOfView(targetFOV, 0.2f).SetEase(Ease.OutSine);
        }

     
        
        
        
        private void Update()
        {
            // Example: Fire trigger
            if (Input.GetKeyDown(KeyCode.F))
            {
                FireRecoil(weaponRecoilStrength);
            }

            // Example: ADS toggle/hold
            if (Input.GetKeyDown(KeyCode.G))
            {
                SetAimDownSights(true);
            }
            else if (Input.GetKeyUp(KeyCode.G))
            {
                SetAimDownSights(false);
            }
        }
    }
}