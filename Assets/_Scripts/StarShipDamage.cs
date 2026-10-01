using System;
using UnityEngine;

namespace TiltanMobileSummer2026
{
    
    
    public class StarShipDamage : MonoBehaviour
    {
        public GameObjectPool starShipDamagePooler;
        private void OnMouseDown()
        {
            Debug.Log("StarShipDamage: OnMouseDown called. Attempting to get a pooled object.");
            DamageNumberTween damageNumber = starShipDamagePooler.GetPooledObject().GetComponent<DamageNumberTween>();
            int damageAmount = UnityEngine.Random.Range(5, 15); // Random damage amount between 5 and 15
            damageNumber.GetComponent<DamageNumberTween>().ExecuteDamageText(damageAmount, transform.position);
        }
        
        
        public void ExecuteDamageText()
        {
            DamageNumberTween damageNumber = starShipDamagePooler.GetPooledObject().GetComponent<DamageNumberTween>();
            int damageAmount = UnityEngine.Random.Range(5, 15); // Random damage amount between 5 and 15
            damageNumber.ExecuteDamageText(damageAmount, transform.position);
        }
    }
}