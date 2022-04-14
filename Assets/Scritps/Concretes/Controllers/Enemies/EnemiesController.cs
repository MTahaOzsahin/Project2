using Project2.Abstract.Controlllers;
using Project2.Concretes.Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Controllers.Enemies
{
    public  class EnemiesController : EnemiesAbstractController
    {
        public override void SetEnemiesPool()
        {
            EnemiesPool.Instance.Set(this);
        }
    }
}

