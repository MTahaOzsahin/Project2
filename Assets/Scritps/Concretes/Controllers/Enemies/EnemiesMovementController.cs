using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Controllers.Enemies
{
    public class EnemiesMovementController : MonoBehaviour
    {
        Rigidbody2D enemiesRigiBody2D;
        Transform enemiesTransform;

        public Vector2[] enemiesWaypoints = new Vector2[15];
        public Tween pathTween;
        private void Awake()
        {
            enemiesRigiBody2D = GetComponent<Rigidbody2D>();
            enemiesTransform = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            //StartCoroutine(enemiesPathMovement());
            //Deneme();
        }
        private void Update()
        {
            enemyPathMovement();
        }
        IEnumerator enemiesPathMovement()
        {
            Vector2[] enemiesWaypoints = new Vector2[16];
            enemiesWaypoints[0] = new Vector2(8.5f, -7.4f);
            enemiesWaypoints[1] = new Vector2(8.5f, -1.5f);
            enemiesWaypoints[2] = new Vector2(0.45f, -1.5f);
            enemiesWaypoints[3] = new Vector2(0.45f, 3f);
            enemiesWaypoints[4] = new Vector2(7.15f, 3f);
            enemiesWaypoints[5] = new Vector2(7.15f, 15f);
            enemiesWaypoints[6] = new Vector2(-1.15f, 15f);
            enemiesWaypoints[7] = new Vector2(8.5f, -7.5f);
            enemiesWaypoints[8] = new Vector2(-1.15f, 15f);
            enemiesWaypoints[9] = new Vector2(7.15f, 15f);
            enemiesWaypoints[10] = new Vector2(7.15f, 3f);
            enemiesWaypoints[11] = new Vector2(0.45f, 3f);
            enemiesWaypoints[12] = new Vector2(0.45f, -1.5f);
            enemiesWaypoints[13] = new Vector2(8.5f, -1.5f);
            enemiesWaypoints[14] = new Vector2(8.5f, -7.4f);

            enemiesRigiBody2D.DOLocalPath(enemiesWaypoints, 16f, PathType.Linear, PathMode.Full3D, 1, Color.red);

            //enemiesTransform.DOLocalPath(enemiesWaypoints, 164f, PathType.Linear, PathMode.Ignore,10,
            //    Color.red).SetOptions(false);


            yield break;
        }
        void enemyPathMovement()
        {
            //Vector2[] enemiesWaypoints = new Vector2[1];
            //enemiesWaypoints[0] = new Vector2(8.5f, -7.4f);
            //enemiesWaypoints[1] = new Vector2(8.5f, -1.5f);
            //enemiesWaypoints[2] = new Vector2(0.45f, -1.5f);
            //enemiesWaypoints[3] = new Vector2(0.45f, 3f);
            //enemiesWaypoints[4] = new Vector2(7.15f, 3f);
            //enemiesWaypoints[5] = new Vector2(7.15f, 15f);
            //enemiesWaypoints[6] = new Vector2(-1.15f, 15f);
            //enemiesWaypoints[7] = new Vector2(8.5f, -7.5f);
            //enemiesWaypoints[8] = new Vector2(-1.15f, 15f);
            //enemiesWaypoints[9] = new Vector2(7.15f, 15f);
            //enemiesWaypoints[10] = new Vector2(7.15f, 3f);
            //enemiesWaypoints[11] = new Vector2(0.45f, 3f);
            //enemiesWaypoints[12] = new Vector2(0.45f, -1.5f);
            //enemiesWaypoints[13] = new Vector2(8.5f, -1.5f);
            //enemiesWaypoints[14] = new Vector2(8.5f, -7.4f);

            pathTween = enemiesRigiBody2D.DOPath(enemiesWaypoints, 16f, PathType.Linear, PathMode.TopDown2D, 5, Color.red);

        }
        private void OnDrawGizmosSelected()
        {
            
        }
    }
}
