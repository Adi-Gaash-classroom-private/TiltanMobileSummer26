
using System;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Random = UnityEngine.Random;


namespace TiltanMobileSummer2026
{
    public class DamageNumberTween: MonoBehaviour
    {
        public GameObjectPool GameObjectPool;
        [SerializeField]
        private TextMeshPro textMesh;

       

        public void ExecuteDamageText(int damageAmount, Vector3 spawnPosition)
        {
            transform.position = spawnPosition;
            textMesh.text = damageAmount.ToString();
            textMesh.alpha = 1f;

            Vector3 targetPosition = spawnPosition + new Vector3(Random.Range(-0.5f, 0.5f), 1.5f, 0f);

            Sequence damageSequence = DOTween.Sequence();

            // Step 1: Scale punch impact
            damageSequence.Append(transform.DOPunchScale(Vector3.one * 0.4f, 0.2f));

            // Step 2: Float upward concurrently with scale
            damageSequence.Join(transform.DOMove(targetPosition, 0.8f).SetEase(Ease.OutCubic));

            // Step 3: Fade out alpha during the second half of movement
            damageSequence.Insert(0.4f, textMesh.DOFade(0f, 0.4f));

            // Step 4: Cleanup on completion
            damageSequence.OnComplete(() => GameObjectPool.ReturnToPool(gameObject));
        }

        private void OnDisable()
        {
            transform.DOKill();
            textMesh.DOKill();
        }
    }
}