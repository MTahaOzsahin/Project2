using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Controllers.Enemies
{
    public class EnemiesAnimationController : MonoBehaviour
    {
        Animator enemiesAnimator;
        Rigidbody2D enemiesRigidbody2D;
        Transform enemiesTransform;

        private void Awake()
        {
            enemiesAnimator = GetComponent<Animator>();
            enemiesRigidbody2D = GetComponent<Rigidbody2D>();
            enemiesTransform = GetComponent<Transform>();
        }
        private void Update()
        {
            EnemiesAnimDecider();
        }

        public enum EnemiesState { Idle, Run , Death, Attack, Attack2}
        public EnemiesState enemiesState;

        public EnemiesState EnemiesState1 { get => enemiesState; set => enemiesState = value; }

        void EnemiesAnimDecider()
        {
            switch (EnemiesState1)
            {
                case EnemiesState.Idle:
                    PlayIdleAnimation();
                    break;
                case EnemiesState.Run:
                    PlayRunAnimation();
                    break;
                case EnemiesState.Death:
                    PlayDeathAnimation();
                    break;
                case EnemiesState.Attack:
                    StartCoroutine(PlayAttackAnimation());
                    break;
                case EnemiesState.Attack2:
                    StartCoroutine(PlayAttack2Animation());
                    break;
                default:
                    break;
            }
        }
       
        void PlayIdleAnimation()
        {
            enemiesAnimator.SetBool("isIdle", true);
            enemiesAnimator.SetBool("isRunning", false);
        }
        void PlayRunAnimation()
        {
            enemiesAnimator.SetBool("isIdle", false);
            enemiesAnimator.SetBool("isRunning", true);
        }
        void PlayDeathAnimation()
        {
            enemiesAnimator.SetBool("isIdle", false);
            enemiesAnimator.SetBool("isRunning", false);
            enemiesAnimator.SetBool("isDeath", true);
        }
        IEnumerator PlayAttackAnimation()
        {
            enemiesAnimator.SetBool("isIdle", false);
            enemiesAnimator.SetBool("isRunning", false);
            enemiesAnimator.SetTrigger("isAttacking");

            yield return new WaitForSeconds(1f);

            enemiesAnimator.SetBool("isIdle", true);
            enemiesAnimator.SetBool("isRunning", false);

            yield break;
        }
        IEnumerator PlayAttack2Animation()
        {
            enemiesAnimator.SetBool("isIdle", false);
            enemiesAnimator.SetBool("isRunning", false);
            enemiesAnimator.SetTrigger("isAttacking2");

            yield return new WaitForSeconds(1f);

            enemiesAnimator.SetBool("isIdle", true);
            enemiesAnimator.SetBool("isRunning", false);

            yield break;
        }
    }
}

