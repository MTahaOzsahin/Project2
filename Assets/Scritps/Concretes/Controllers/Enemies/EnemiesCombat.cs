using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Controllers.Enemies
{
    public class EnemiesCombat : MonoBehaviour
    {
        EnemiesAnimationController enemiesAnimationController;
        Rigidbody2D enemiesRigiBody2D;
        Transform enemiesTransform;
        

        bool isMainCharacterNear = false;

        [SerializeField] Transform mainCharacterTransfrom;    //MainCharacter's transfrom will add manually via Unity inspector

        private void Awake()
        {
            enemiesTransform = GetComponent<Transform>();
            enemiesRigiBody2D = GetComponent<Rigidbody2D>();
            enemiesAnimationController = GetComponent<EnemiesAnimationController>();
        }
        private void FixedUpdate()
        {
           
        }
        private void Update()
        {
            Detacher();
            Chase();
        }

       
        void Detacher()
        {
            Collider2D[] areaResult = Physics2D.OverlapCircleAll(enemiesTransform.position, 3f);
            foreach (Collider2D result in areaResult)
            {
                if (result.gameObject.CompareTag("Player"))
                {
                    isMainCharacterNear = true;
                }
                //if (result.gameObject.CompareTag("Player") == null)
                //{
                //    isMainCharacterNear = false;
                //}
            }
        }
        

        void Chase()
        {
            Vector2 limitor;
            limitor = new  Vector3(1f, 1f);
            Vector3 offset;
            offset = enemiesTransform.position - mainCharacterTransfrom.position;
            if (isMainCharacterNear)
            {
                enemiesRigiBody2D.velocity = -offset;
            }
            //if (Mathf.Abs(enemiesRigiBody2D.velocity.x) > 3 || Mathf.Abs(enemiesRigiBody2D.velocity.y) > 3)
            //{
            //    enemiesRigiBody2D.velocity = -offset / 6;
            //    Debug.Log("velocity is high");
            //}
        }

        
    }
}
