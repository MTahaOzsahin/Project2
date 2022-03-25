using System.Collections;
using System.Collections.Generic;
using Project2.Concretes.Controllers.MainCharacter;
using DG.Tweening;
using UnityEngine;

namespace Project2.Concretes.Controllers.MainCharacter
{
    public class MainCharacterCombat : MonoBehaviour
    {
        SpriteRenderer mainCharacterSpriteRenderer;
        MainCharacterAnimationController mainCharacterAnimationController;
        MainCharacterMovementController mainCharacterMovementController;

        float delayAttackTime = 1f;
        float currentDelayTime;
        bool canAttack = false;

        private void Awake()
        {
            mainCharacterSpriteRenderer = GetComponent<SpriteRenderer>();
            mainCharacterAnimationController = GetComponent<MainCharacterAnimationController>();
            mainCharacterMovementController = GetComponent<MainCharacterMovementController>();
        }
        private void Update()
        {
            AttackTimer();
            AttackAction();
            InvisibilitySkill();
        }
        void AttackTimer()
        {
            currentDelayTime += Time.deltaTime;
            if (currentDelayTime > delayAttackTime)
            {
                canAttack = true;
            }
            else
            {
                canAttack = false;
            }
        }
        public void AttackAction()
        {
            if (canAttack)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine(mainCharacterAnimationController.PlayAttackOrder1());
                    currentDelayTime = 0f;
                }
                
            }
            
        }

        void InvisibilitySkill()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                mainCharacterMovementController.RunSpeed = new float(); //Stopped here
                mainCharacterSpriteRenderer.DOFade(0.55f, 0.5f);
                Tween fadeTween = mainCharacterSpriteRenderer.DOFade(0.55f, 0.3f);
                
                Tween fadeBackTween = mainCharacterSpriteRenderer.DOFade(1f, 0.3f);
                fadeBackTween.SetDelay<Tween>(2f);
                mainCharacterMovementController.RunSpeed = 6f;
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                mainCharacterMovementController.RunSpeed = 10f;
                Color colorOriginal = new Color();
                colorOriginal = mainCharacterSpriteRenderer.color;
                Color color = new Color();
                color.a = 0.8f;
                
                Tween colorTween = mainCharacterSpriteRenderer.DOColor(color, 0.3f);

                Tween colorBackTween = mainCharacterSpriteRenderer.DOColor(colorOriginal,0.3f);
                colorBackTween.SetDelay<Tween>(2f);
                mainCharacterMovementController.RunSpeed = 6f;
            }
        }
        
        
    }
}
