using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Controllers.Enemies
{
    public class EnemiesMovementController : MonoBehaviour
    {
        
        Transform enemiesTransform;
        Rigidbody2D enemiesRigidbody2D;
        EnemiesAnimationController enemiesAnimationController;

       
        private void Awake()
        {
            enemiesTransform = GetComponent<Transform>();
            enemiesRigidbody2D = GetComponent<Rigidbody2D>();
            enemiesAnimationController = GetComponent<EnemiesAnimationController>();
        }
        private void Start()
        {
            StartCoroutine(enemiesPathMovement());
        }

        private void FixedUpdate()
        {
            
        }
        private void Update()
        {
            Debug.Log(enemiesRigidbody2D.velocity.magnitude);
        }
        IEnumerator enemiesPathMovement()
        {
            Vector3[] enemiesWaypoints = new Vector3[11];
            enemiesWaypoints[0] = new Vector3(-2f, -7.4f);
            enemiesWaypoints[1] = new Vector3(8.5f, -7.4f);
            enemiesWaypoints[2] = new Vector3(8.5f, -1.5f);
            enemiesWaypoints[3] = new Vector3(0.45f, -1.5f);
            enemiesWaypoints[4] = new Vector3(0.45f, 3f);
            enemiesWaypoints[5] = new Vector3(7.15f, 3f);
            enemiesWaypoints[6] = new Vector3(7.15f, 3f);
            enemiesWaypoints[7] = new Vector3(0.45f, 3f);
            enemiesWaypoints[8] = new Vector3(0.45f, -1.5f);
            enemiesWaypoints[9] = new Vector3(8.5f, -1.5f);
            enemiesWaypoints[10] = new Vector3(8.5f, -7.4f);

            enemiesTransform.DOPath(enemiesWaypoints, 16f, PathType.Linear, PathMode.Ignore, 1, Color.red).SetOptions(true);

            enemiesRigidbody2D.velocity = new Vector2(10f, 10f);



            enemiesAnimationController.EnemiesState1 = EnemiesAnimationController.EnemiesState.Run;

           

            yield return new WaitForSeconds(16f);

           

            enemiesAnimationController.EnemiesState1 = EnemiesAnimationController.EnemiesState.Idle;

          
            yield break;
        }
       
        private void OnDrawGizmosSelected()
        {
            
        }
    }
}
