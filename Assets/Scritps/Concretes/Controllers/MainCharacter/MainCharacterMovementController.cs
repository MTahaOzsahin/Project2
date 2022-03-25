using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Controllers.MainCharacter
{
    public class MainCharacterMovementController : MonoBehaviour
    {
        Rigidbody2D mainCharacterRigibody;
        SpriteRenderer mainCharacterSpriteRenderer;

       



        [SerializeField] float runSpeed;

        public float RunSpeed { get => runSpeed; set => runSpeed = value; }

        private void Awake()
        {
            mainCharacterRigibody = GetComponent<Rigidbody2D>();
            mainCharacterSpriteRenderer = GetComponent<SpriteRenderer>();
           

        }

        public void Movement()
        {
            if (Input.GetKey(KeyCode.D))
            {
                mainCharacterRigibody.velocity = new Vector2(RunSpeed, mainCharacterRigibody.velocity.y);
                mainCharacterSpriteRenderer.flipX = false;
            }
            if (Input.GetKey(KeyCode.A))
            {
                mainCharacterRigibody.velocity = new Vector2(-RunSpeed, mainCharacterRigibody.velocity.y);
                mainCharacterSpriteRenderer.flipX = true;
            }
            if (Input.GetKey(KeyCode.W))
            {
                mainCharacterRigibody.velocity = new Vector2(mainCharacterRigibody.velocity.x, RunSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                mainCharacterRigibody.velocity = new Vector2(mainCharacterRigibody.velocity.x, -RunSpeed);
            }
            

        }



        private void FixedUpdate()
        {
            Movement();
        }
    }
}

