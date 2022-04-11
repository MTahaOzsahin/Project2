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
        bool isAttackAvailable = false;

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
            ChaseAndAttack();
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
            Collider2D[] hitResult = Physics2D.OverlapCircleAll(enemiesTransform.position, 0.8f);
            foreach (Collider2D hit in hitResult)
            {
                if (hit.gameObject.CompareTag("Player"))
                {
                    isAttackAvailable = true;
                }
            }
        }
        

        void ChaseAndAttack()
        {
            Vector2 limitor;
            limitor = new  Vector3(1f, 1f);
            Vector3 offset;
            offset = enemiesTransform.position - mainCharacterTransfrom.position;
            if (isMainCharacterNear)
            {
                enemiesRigiBody2D.velocity = -offset * 2;
                isMainCharacterNear = false;
            }
            if (isAttackAvailable)
            {
                StartCoroutine(AttackOrder());
                isAttackAvailable = false;
            }

            IEnumerator AttackOrder()
            {
                
                 enemiesAnimationController.EnemiesState1 = EnemiesAnimationController.EnemiesState.Attack;
                 yield return new WaitForSeconds(0.1f);
                 enemiesAnimationController.EnemiesState1 = EnemiesAnimationController.EnemiesState.Run;
                
                yield break;
            }
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("PlayerHit"))
            {
                Debug.Log("hit");
                Destroy(this.gameObject);
            }
        }

    }
}
