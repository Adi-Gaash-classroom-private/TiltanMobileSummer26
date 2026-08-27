using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class Gun : MonoBehaviour
    {
        [Header("Spawn Settings")] public GameObject bulletPrefab;
        public float fireRate = 0.15f; // seconds between shots
        public Transform ShootingPoint;
        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= fireRate && Input.GetKey(KeyCode.Space))
            {
                Instantiate(bulletPrefab, ShootingPoint.position,
                    ShootingPoint.rotation);
                _timer = 0f;
            }
        }
    }
}

