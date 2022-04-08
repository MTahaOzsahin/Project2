using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Controllers.Enemies
{
    public class EnemiesCombat : MonoBehaviour
    {
        EnemiesAnimationController enemiesAnimationController;
        

        private void Awake()
        {
            enemiesAnimationController = GetComponent<EnemiesAnimationController>();
        }
        private void FixedUpdate()
        {
           
        }

        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                enemiesAnimationController.EnemiesState1 = EnemiesAnimationController.EnemiesState.Attack2;
                Debug.Log("Player detected");
            }
        }

        
    }
}
