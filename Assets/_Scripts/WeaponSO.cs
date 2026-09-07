using UnityEngine;

namespace TiltanMobileSummer2026
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/Weapon Data")]
    public class WeaponSO : ScriptableObject
    {
        [Header("Stats")]
        public int damage = 34;
        public float fireRate = 4.0f;
        public float range = 40f;
        public int maxAmmo = 12;
        

        public virtual void ExecuteFire(Transform muzzle, GameObjectPool pool)
        {
            if (muzzle == null || pool == null) return;
            SpawnBullet(muzzle.position, muzzle.rotation, pool);
        }

        protected void SpawnBullet(Vector3 pos, Quaternion rot, GameObjectPool pool)
        {
            GameObject bullet = pool.GetPooledObject();
            if (bullet == null) return;
            bullet.transform.position = pos;
            bullet.transform.rotation = rot;
        }

        private void Reset()
        {
            damage = 34;
            fireRate = 4.0f;
            range = 40f;
            maxAmmo = 12;
        }
    }
}