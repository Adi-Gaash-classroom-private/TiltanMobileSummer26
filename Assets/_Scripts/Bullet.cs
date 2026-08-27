using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class Bullet : MonoBehaviour
    {
        
        public GameObjectPool GameObjectPool;
        public float speed = 15f;
        public float maxDistance = 20f; // distance from spawn

        private Vector3 _startPosition;

        private void OnEnable()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            var distance = Vector3.Distance(
                transform.position, _startPosition);
            if (distance >= maxDistance)
            {
                GameObjectPool.ReturnToPool(gameObject);
                return;
            }

            transform.Translate(Vector3.forward * speed
                                                * Time.deltaTime);
        }
    }
}