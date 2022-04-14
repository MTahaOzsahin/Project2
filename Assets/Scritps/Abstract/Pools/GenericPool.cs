using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Abstract.Pools
{
    public abstract class GenericPool<T> : MonoBehaviour where T : Component
    {
        [SerializeField] T[] prefabs;
        [SerializeField] int countLoop = 15;

        Queue<T> poolPrefabs = new Queue<T>();

        private void Awake()
        {
            SingletonObject();
        }
        private void Start()
        {
            GrowPoolPrefab();
        }

        protected abstract void SingletonObject();
        public T Get()
        {
            if (poolPrefabs.Count == 0)
            {
                GrowPoolPrefab();
            }

            return poolPrefabs.Dequeue();
        }

        public abstract void ResetAllObject();

        private void GrowPoolPrefab()
        {
            for (int i = 0; i < countLoop; i++)
            {
                T newPrefab = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
                newPrefab.transform.parent = this.transform;
                newPrefab.gameObject.SetActive(false);
                poolPrefabs.Enqueue(newPrefab);
            }
        }

        public  void Set(T poolObject)
        {
            poolObject.gameObject.SetActive(false);
            poolPrefabs.Enqueue(poolObject);

        }
        

    }
}

