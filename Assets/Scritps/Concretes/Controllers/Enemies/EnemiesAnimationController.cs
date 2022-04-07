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

        public enum EnemiesState { Idle, Run , Death}
        EnemiesState enemiesState;

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
    }
}

