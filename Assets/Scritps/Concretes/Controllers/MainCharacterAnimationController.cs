using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Controllers
{
    public class MainCharacterAnimationController : MonoBehaviour
    {
        Animator animator;
        Rigidbody2D mainCharacterRigibody;

        public enum CharacterState { Idle, Run, Attack1, Attack2}
        public CharacterState characterState;


        private void Awake()
        {
            animator = GetComponent<Animator>();
            mainCharacterRigibody = GetComponent<Rigidbody2D>();
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
            if (characterState == CharacterState.Attack1)
                yield break;

            characterState = CharacterState.Attack1;
            animator.SetTrigger("isAttacking1");

            new WaitForSeconds(0.55f);
            characterState = CharacterState.Idle;
            yield break;
        }
        public IEnumerator PlayAttackOrder2()
        {
            if (characterState == CharacterState.Attack2)
                yield break;

            characterState = CharacterState.Attack2;
            animator.SetTrigger("isAttacking2");

            new WaitForSeconds(0.55f);
            characterState = CharacterState.Idle;

            yield break;
        }
        

        

        void PlayAnimation()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(PlayAttackOrder1());
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine(PlayAttackOrder2());
            }
            if (mainCharacterRigibody.velocity.magnitude < 1f)
            {
                characterState = CharacterState.Idle;
                PlayIdleAnim();
            }
            if (mainCharacterRigibody.velocity.magnitude > 1f)
            {
                characterState = CharacterState.Run;
                PlayRunningAnim();
            }
           
        }



        private void Update()
        {
            PlayAnimation();
        }


    }
}
