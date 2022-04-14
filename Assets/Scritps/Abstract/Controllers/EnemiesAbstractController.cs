using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Abstract.Controlllers
{
    public abstract class EnemiesAbstractController : EnemiesLifeController
    {
        public override void KillGameObject()
        {
            SetEnemiesPool();
        }
        public abstract void SetEnemiesPool();
    }
}

