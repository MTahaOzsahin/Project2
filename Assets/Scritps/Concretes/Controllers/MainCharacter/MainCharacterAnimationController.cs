using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Controllers.MainCharacter
{
    public class MainCharacterAnimationController : MonoBehaviour
    {
        Animator animator;
        Rigidbody2D mainCharacterRigibody;

        public enum CharacterState { Idle, Run}
        public CharacterState characterState;


        private void Awake()
        {
            animator = GetComponent<Animator>();
            mainCharacterRigibody = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            CharacterAnimDecider();
            CharacterStateDecider();
        }
        public void PlayIdleAnim()
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isRunning", false);
            characterState = CharacterState.Idle;
        }
        public void PlayRunningAnim()
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isRunning", true);
            characterState = CharacterState.Run;
        }
        public IEnumerator PlayAttackOrder1()
        {
            animator.SetTrigger("isAttacking1");
            yield break;
        }
        public IEnumerator PlayAttackOrder2()
        {
            animator.SetTrigger("isAttacking2");
            yield break;
        }
        
        void CharacterAnimDecider()
        {
            switch (characterState)
            {
                case CharacterState.Idle:
                    PlayIdleAnim();
                    break;
                case CharacterState.Run:
                    PlayRunningAnim();
                    break;
                default:
                    break;
            }
        }
        
        void CharacterStateDecider()
        {
            if (Mathf.Abs(mainCharacterRigibody.velocity.x) < 1f && Mathf.Abs(mainCharacterRigibody.velocity.y) < 1f)
            {
                characterState = CharacterState.Idle;
            }
            else
            {
                characterState = CharacterState.Run;
            }

        }

        



       


    }
}
