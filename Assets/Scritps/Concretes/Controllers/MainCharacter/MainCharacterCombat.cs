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
        Transform mainCharacterTransform;
        MainCharacterAnimationController mainCharacterAnimationController;
        MainCharacterMovementController mainCharacterMovementController;


        float delayAttackTime = 1f;
        float delayInvisibilitySkill = 10f;
        float delayDashSkill = 5f;
        float currentAttackDelayTime=1f;
        float currentInvisibilitySkillDelayTime=10f;
        float currentDashSkillDelayTime=5f;
        bool canAttack = false;
        bool canInvisiblityskill = true;
        bool canDashSkill = true;

        private void Awake()
        {
            mainCharacterSpriteRenderer = GetComponent<SpriteRenderer>();
            mainCharacterTransform = GetComponent<Transform>();
            mainCharacterAnimationController = GetComponent<MainCharacterAnimationController>();
            mainCharacterMovementController = GetComponent<MainCharacterMovementController>();
        }
        private void Update()
        {
            AttackAction();
            StartCoroutine(InvisibilitySkill());
            DashSkill();
        }

        public void AttackAction()
        {
            currentAttackDelayTime += Time.deltaTime;
            if (currentAttackDelayTime > delayAttackTime)
            {
                canAttack = true;
            }
            else
            {
                canAttack = false;
            }
            if (canAttack)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine(mainCharacterAnimationController.PlayAttackOrder1());
                    currentAttackDelayTime = 0f;
                }
            }
        }
       
        IEnumerator InvisibilitySkill()
        {
            currentInvisibilitySkillDelayTime += Time.deltaTime;
            if (currentInvisibilitySkillDelayTime > delayInvisibilitySkill)
            {
                canInvisiblityskill = true;
            }
            else
            {
                canInvisiblityskill = false;
            }
            if (canInvisiblityskill)
            {
               
                    if (Input.GetKeyDown(KeyCode.K))
                    {
                        canInvisiblityskill = false;
                        currentInvisibilitySkillDelayTime = 0f;
                        mainCharacterMovementController.RunSpeed = 12f;
                        Color colorOriginal = new Color();
                        colorOriginal = mainCharacterSpriteRenderer.color;
                        Color color = new Color();
                        color.a = 0.8f;

                        Tween colorTween = mainCharacterSpriteRenderer.DOColor(color, 0.3f);

                        Tween colorBackTween = mainCharacterSpriteRenderer.DOColor(colorOriginal, 0.3f);
                        colorBackTween.SetDelay<Tween>(5f);
                        yield return new WaitForSeconds(5f);
                        mainCharacterMovementController.RunSpeed = 6f;
                    }
                    yield break;
                
            }

           
        }

        void DashSkill()
        {
            Color colorOriginal = new Color();
            colorOriginal = mainCharacterSpriteRenderer.color;
            Color color = new Color();
            color = Color.red;

            currentDashSkillDelayTime += Time.deltaTime;
            if (currentDashSkillDelayTime > delayDashSkill)
            {
                canDashSkill = true;
            }
            else
            {
                canDashSkill = false;
            }

            if (canDashSkill)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
                {
                    canDashSkill = false;
                    currentDashSkillDelayTime = 0f;

                    Tween colorTween = mainCharacterSpriteRenderer.DOColor(color, 0.01f);
                    Tween colorBackTween = mainCharacterSpriteRenderer.DOColor(colorOriginal, 0.01f);
                    colorBackTween.SetDelay<Tween>(0.3f);

                    Tween shakeTween = mainCharacterTransform.DOShakePosition(0.3f, 0.3f, 3, 10, false, true);


                    mainCharacterSpriteRenderer.DOFade(0.55f, 0.01f);
                    Tween fadeBackTween = mainCharacterSpriteRenderer.DOFade(1f, 0.01f);
                    fadeBackTween.SetDelay<Tween>(0.3f);

                    mainCharacterTransform.DOMoveX(mainCharacterTransform.position.x + 4, 0.3f, false);
                }
                else if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
                {
                    canDashSkill = false;
                    currentDashSkillDelayTime = 0f;

                    Tween colorTween = mainCharacterSpriteRenderer.DOColor(color, 0.01f);
                    Tween colorBackTween = mainCharacterSpriteRenderer.DOColor(colorOriginal, 0.01f);
                    colorBackTween.SetDelay<Tween>(0.3f);

                    Tween shakeTween = mainCharacterTransform.DOShakePosition(0.3f, 0.3f, 3, 10, false, true);

                    mainCharacterSpriteRenderer.DOFade(0.55f, 0.01f);
                    Tween fadeBackTween = mainCharacterSpriteRenderer.DOFade(1f, 0.01f);
                    fadeBackTween.SetDelay<Tween>(0.3f);

                    mainCharacterTransform.DOMoveX(mainCharacterTransform.position.x - 4, 0.3f, false);
                }
                else if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
                {
                    canDashSkill = false;
                    currentDashSkillDelayTime = 0f;

                    Tween colorTween = mainCharacterSpriteRenderer.DOColor(color, 0.01f);
                    Tween colorBackTween = mainCharacterSpriteRenderer.DOColor(colorOriginal, 0.01f);
                    colorBackTween.SetDelay<Tween>(0.3f);

                    Tween shakeTween = mainCharacterTransform.DOShakePosition(0.3f, 0.3f, 3, 10, false, true);

                    mainCharacterSpriteRenderer.DOFade(0.55f, 0.01f);
                    Tween fadeBackTween = mainCharacterSpriteRenderer.DOFade(1f, 0.01f);
                    fadeBackTween.SetDelay<Tween>(0.3f);

                    mainCharacterTransform.DOMoveY(mainCharacterTransform.position.y + 4, 0.3f, false);
                }
                else if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
                {
                    canDashSkill = false;
                    currentDashSkillDelayTime = 0f;

                    Tween colorTween = mainCharacterSpriteRenderer.DOColor(color, 0.01f);
                    Tween colorBackTween = mainCharacterSpriteRenderer.DOColor(colorOriginal, 0.01f);
                    colorBackTween.SetDelay<Tween>(0.3f);

                    Tween shakeTween = mainCharacterTransform.DOShakePosition(0.3f, 0.3f, 3, 10, false, true);

                    mainCharacterSpriteRenderer.DOFade(0.55f, 0.01f);
                    Tween fadeBackTween = mainCharacterSpriteRenderer.DOFade(1f, 0.01f);
                    fadeBackTween.SetDelay<Tween>(0.3f);

                    mainCharacterTransform.DOMoveY(mainCharacterTransform.position.y - 4, 0.3f, false);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision)
            {
                Debug.Log(collision.name);
            }
        }


    }
}
