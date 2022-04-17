using Project2.Abstract.Controlllers;
using Project2.Concretes.Controllers.Enemies;
using Project2.Concretes.Managers;
using Project2.Concretes.Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Spawner
{
    public class EnemiesSpawner : MonoBehaviour
    {
        private void Awake()
        {
          
        }

        private void Update()
        {
            SpawnDetecter();       
        }

        void SpawnDetecter()
        {
            GameObject[] _enemiesCounter = GameObject.FindGameObjectsWithTag("Enemies");

            
            if (_enemiesCounter.Length <= 8)
            {
                Spawn();
            }
            
        }
        public void Spawn()
        {
            GameObject[] spawnerLocations = GameObject.FindGameObjectsWithTag("Spawners");
            
                EnemiesAbstractController poolEnemies = EnemiesPool.Instance.Get();
            poolEnemies.transform.position = spawnerLocations[Random.Range(1,7)].transform.position;
            poolEnemies.gameObject.SetActive(true);
            
        }
    }
}
