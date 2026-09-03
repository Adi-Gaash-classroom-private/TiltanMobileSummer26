using UnityEngine;

namespace TiltanMobileSummer2026
{
    [CreateAssetMenu(fileName = "BurstFireWeaponData", menuName = "Weapons/Burst Fire Weapon")]
    public class BurstFireWeaponSO : WeaponSO
    {
        [Header("Burst Settings")]
        public int burstCount = 3;

        public override void ExecuteFire(Transform muzzle, GameObjectPool pool)
        {
            if (muzzle == null || pool == null) return;

            for (int i = 0; i < Mathf.Max(1, burstCount); i++)
            {
                SpawnBullet(muzzle.position, muzzle.rotation, pool);
            }
        }

        private void Reset()
        {
            burstCount = 3;
        }
    }
}