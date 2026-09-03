using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class Gun : MonoBehaviour
    {
        public GameObjectPool GameObjectPool;
        public WeaponSO weaponData;
        public float fallbackFireRate = 0.15f; // seconds between shots when no weapon data provided
        public Transform ShootingPoint;
        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;
            float interval = fallbackFireRate;
            if (weaponData != null && weaponData.fireRate > 0f)
                interval = 1f / weaponData.fireRate; // weaponData.fireRate treated as shots-per-second

            if (_timer >= interval && Input.GetKey(KeyCode.Space))
            {
                if (weaponData != null)
                {
                    weaponData.ExecuteFire(ShootingPoint, GameObjectPool);
                }
             
                _timer = 0f;
            }
        }
    }
}

