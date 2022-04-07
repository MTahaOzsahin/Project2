using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Controllers.Enemies
{
    public class EnemiesMovementController : MonoBehaviour
    {
        
        Transform enemiesTransform;
        SpriteRenderer enemiesSpriteRenderer;
        EnemiesAnimationController enemiesAnimationController;

        enum EnemiesType { level1,level2,level3}
        [SerializeField] EnemiesType enemiesType;


        [SerializeField] Vector3[] enemiesPathLevel1;
        [SerializeField] Vector3[] enemiesPathLevel2;
        [SerializeField] Vector3[] enemiesPathLevel3;

        Vector3 enemiesStartPosition;
        Vector3 enemiesLastPosition;
        Vector3 enemiesLastPosition1;

        

       
        private void Awake()
        {
            enemiesTransform = GetComponent<Transform>();
            enemiesSpriteRenderer = GetComponent<SpriteRenderer>();
            enemiesAnimationController = GetComponent<EnemiesAnimationController>();
        }
        private void Start()
        {
            enemiesStartPosition = enemiesTransform.position;
           
            //StartCoroutine(enemiesPathMovement());
        }

        private void FixedUpdate()
        {
           
        }
        private void Update()
        {
            enemiesMovementDetector();
            enemiesFaceDirection();
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(enemiesPathMovement());
            }
        }
       
        IEnumerator enemiesPathMovement()
        {
            switch (enemiesType)
            {
                case EnemiesType.level1:
                    //Sequence level1Sequence = DOTween.Sequence().SetLoops(-1);
                    //level1Sequence.SetDelay(3f);
                    //level1Sequence.Append(enemiesTransform.DOPath(enemiesPathLevel1, 5f, PathType.Linear, PathMode.Ignore, 1, Color.red).SetOptions(false).
                    //    SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo));
                    //level1Sequence.AppendInterval(3f);
                    Tween TweenPathLevel1 = enemiesTransform.DOPath(enemiesPathLevel1, 16f, PathType.Linear, PathMode.Ignore, 1, Color.red).SetOptions(false).
                        SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
                    
                    break;
                case EnemiesType.level2:
                    Tween TweenPathLevel2 = enemiesTransform.DOPath(enemiesPathLevel2, 14f, PathType.Linear, PathMode.Ignore, 1, Color.red).SetOptions(false).
                        SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
                    break;
                case EnemiesType.level3:
                    Tween TweenPathLevel3 = enemiesTransform.DOPath(enemiesPathLevel3, 4f, PathType.Linear, PathMode.Ignore, 1, Color.red).SetOptions(false).
                        SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
                    break;
                default:
                    break;
            }
           

            
            yield break;
        }
        void enemiesMovementDetector()
        {
            float threshold = 0.0f;
            Vector3 offset = enemiesTransform.position - enemiesLastPosition;
            enemiesLastPosition = enemiesTransform.position;
            
            if (offset.x > threshold || offset.y > threshold)
            {
                enemiesLastPosition = enemiesTransform.position;
                enemiesAnimationController.EnemiesState1 = EnemiesAnimationController.EnemiesState.Run;
            }
            if (offset.x < threshold || offset.y < threshold)
            {
                enemiesLastPosition = enemiesTransform.position;
                enemiesAnimationController.EnemiesState1 = EnemiesAnimationController.EnemiesState.Run;
            }
            if (enemiesTransform.position == enemiesStartPosition)
            {
                enemiesAnimationController.EnemiesState1 = EnemiesAnimationController.EnemiesState.Idle;
            }
        }
        void enemiesFaceDirection()
        {
            float threshold = 0.0f;
            Vector3 offset = enemiesTransform.position - enemiesLastPosition1;
            if (offset.x >threshold)
            {
                enemiesSpriteRenderer.flipX = false;
                enemiesLastPosition1 = enemiesTransform.position;
            }
            if (offset.x < -threshold)
            {
                enemiesSpriteRenderer.flipX = true;
                enemiesLastPosition1 = enemiesTransform.position;
            }
        }
        private void OnDrawGizmosSelected()
        {
            
        }
    }
}
