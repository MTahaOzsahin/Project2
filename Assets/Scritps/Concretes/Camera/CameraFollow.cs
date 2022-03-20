using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform targetObject;
        public float lerpSpeed = 1f;

        Vector3 offset;
        Vector3 targetObjectPos;

        private void Start()
        {
            if (targetObject == null) return;

            offset = transform.position - targetObject.position;
        }

        private void Update()
        {
            if (targetObject == null) return;

            targetObjectPos = targetObject.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetObjectPos, lerpSpeed * Time.deltaTime);
            
        }
    }
}
