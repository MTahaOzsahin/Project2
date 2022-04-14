using Project2.Concretes.Controllers.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Abstract.Controlllers
{
    public abstract class EnemiesLifeController : MonoBehaviour
    {
        EnemiesCombat enemiesCombat;
        private void Awake()
        {
            enemiesCombat = GetComponent<EnemiesCombat>();
        }
        private void Update()
        {
            if (enemiesCombat.IsDeath)
            {
                KillGameObject();
            }
        }



        public abstract void KillGameObject();
    }
}

