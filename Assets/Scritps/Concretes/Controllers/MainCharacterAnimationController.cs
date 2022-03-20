using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Controllers
{
    public class MainCharacterAnimationController : MonoBehaviour
    {
        Animator animator;
        Rigidbody2D mainCharacterRigibody;
        


        private void Awake()
        {
            animator = GetComponent<Animator>();
            mainCharacterRigibody = GetComponent<Rigidbody2D>();
        }
        public void PlayIdleAnim()
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isRunning", false);
        }
        public void PlayRunningAnim()
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isRunning", true);
        }

        void PlayAnimation()
        {
            if (mainCharacterRigibody.velocity.magnitude < 1f)
            {
                PlayIdleAnim();
            }
            else
            {
                PlayRunningAnim();
            }
        }
        private void Update()
        {
            PlayAnimation();
        }


    }
}
