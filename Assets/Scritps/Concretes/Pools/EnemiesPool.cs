using Project2.Abstract.Pools;
using Project2.Concretes.Controllers.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Pools
{
    public class EnemiesPool : GenericPool<EnemiesController>
    {
        public static EnemiesPool Instance { get; private set; }

        public override void ResetAllObject()
        {
            foreach (EnemiesController child in GetComponentsInChildren<EnemiesController>())
            {
                if (!child.gameObject.activeSelf) continue;

                child.KillGameObject();
            }
        }

        protected override void SingletonObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
