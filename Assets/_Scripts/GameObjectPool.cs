using System;
using System.Collections.Generic;
using UnityEngine;

namespace TiltanMobileSummer2026
{
    public class GameObjectPool : MonoBehaviour
    {
        
        
        
        [SerializeField] private GameObject prefab;
        [SerializeField] private int poolSize = 10;

        
        Queue<GameObject> pool = new Queue<GameObject>();

        private void Awake()
        {
            InitPool(prefab, poolSize);
        }

        void InitPool(GameObject prefab, int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = InitObject();
                obj.SetActive(false);
                pool.Enqueue(obj);
            }
        }

        GameObject InitObject()
        {
            
            GameObject gameObject = Instantiate(prefab);
            gameObject.GetComponent<Bullet>().GameObjectPool = this;
            return gameObject;
        }

        public GameObject GetPooledObject()
        {
            if (pool.Count > 0)
            {
                GameObject obj = pool.Dequeue();
                obj.SetActive(true);
                return obj;
            }
            else
            {
                GameObject obj = InitObject();
                obj.SetActive(true);
                return obj;
            }
        }
        
        public void ReturnToPool(GameObject obj)
        {
            pool.Enqueue(obj);
            obj.SetActive(false);
        }
    }
}
