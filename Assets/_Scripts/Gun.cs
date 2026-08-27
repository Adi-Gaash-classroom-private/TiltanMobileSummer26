using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class Gun : MonoBehaviour
    {
        public GameObjectPool GameObjectPool;
        public float fireRate = 0.15f; // seconds between shots
        public Transform ShootingPoint;
        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= fireRate && Input.GetKey(KeyCode.Space))
            {
                GameObject bullet = GameObjectPool.GetPooledObject();
                if (bullet != null)
                {
                    bullet.transform.position = ShootingPoint.position;
                    bullet.transform.rotation = ShootingPoint.rotation;
                }
                _timer = 0f;
            }
        }
    }
}

