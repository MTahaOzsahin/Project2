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

        bool isDeath = false;
        public bool IsDeath { get => isDeath; set => isDeath = value; }

        private void Awake()
        {
            enemiesTransform = GetComponent<Transform>();
            enemiesRigiBody2D = GetComponent<Rigidbody2D>();
            enemiesAnimationController = GetComponent<EnemiesAnimationController>();
        }
        private void FixedUpdate()
        {
            Debug.Log(isMainCharacterNear);
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
                
            }
            Collider2D[] hitResult = Physics2D.OverlapCircleAll(enemiesTransform.position, 0.5f);
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
            Vector3 offset;
            offset.x = Mathf.Clamp(0f, 0f, 5f);
            offset.y = Mathf.Clamp(0f, 0f, 5f);
            offset = enemiesTransform.position - mainCharacterTransfrom.position;
            if (isMainCharacterNear)
            {
                enemiesRigiBody2D.velocity = -offset * 2;
                isMainCharacterNear = false;
            }
            if (isAttackAvailable)
            {
                enemiesRigiBody2D.velocity = new Vector2(0, 0);
                StartCoroutine(AttackOrder());
                isAttackAvailable = false;
            }

            IEnumerator AttackOrder()
            {
                if (isDeath)
                    yield break;
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
                StartCoroutine(DeathOrder());
               IEnumerator DeathOrder()
                {
                    enemiesAnimationController.EnemiesState1 = EnemiesAnimationController.EnemiesState.Death;
                    isDeath = true;
                    yield return new WaitForSeconds(2.2f);
                    Destroy(this.gameObject);
                    yield break;
                }
            }
        }

    }
}
