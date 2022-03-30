using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Controllers.Enemies
{
    public class EnemiesAnimationController : MonoBehaviour
    {
        Animator enemiesAnimator;
        Rigidbody2D enemiesRigidbody2D;

        private void Awake()
        {
            enemiesAnimator = GetComponent<Animator>();
            enemiesRigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            EnemiesAnimDecider();
            EnemiesStateDecider();
        }

        public enum EnemiesState { Idle, Run , Death}
        EnemiesState enemiesState;

        void EnemiesAnimDecider()
        {
            switch (enemiesState)
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
                default:
                    break;
            }
        }
        void EnemiesStateDecider()
        {
            if (Mathf.Abs(enemiesRigidbody2D.velocity.x) < 1f && Mathf.Abs(enemiesRigidbody2D.velocity.y) <1f)
            {
                enemiesState = EnemiesState.Idle;
            }
            else
            {
                enemiesState = EnemiesState.Run;
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
            enemiesAnimator.SetBool("isRunnig", true);
        }
        void PlayDeathAnimation()
        {

        }
    }
}

