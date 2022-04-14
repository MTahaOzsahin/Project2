using Project2.Abstract.Controlllers;
using Project2.Concretes.Controllers.Enemies;
using Project2.Concretes.Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Spawner
{
    public class EnemiesSpawner : MonoBehaviour
    {
        EnemiesCombat enemiesCombat;
        private void Awake()
        {
            enemiesCombat = GetComponent<EnemiesCombat>();
        }

        private void Update()
        {
            Spawn();
        }
        public void Spawn()
        {
            if (enemiesCombat.IsDeath)
            {
                enemiesCombat.IsDeath = false;
                EnemiesAbstractController poolEnemies = EnemiesPool.Instance.Get();
                poolEnemies.transform.position = this.transform.position;
                poolEnemies.gameObject.SetActive(true);
            }
        }
    }
}
