using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Controllers
{
    public class MainCharacterController : MonoBehaviour
    {
        Rigidbody2D mainCharacterRigibody;
        SpriteRenderer mainCharacterSpriteRenderer;
        

       
        [SerializeField] float runSpeed;
        

        private void Awake()
        {
            mainCharacterRigibody = GetComponent<Rigidbody2D>();
            mainCharacterSpriteRenderer = GetComponent<SpriteRenderer>();
           
        }

        void Movement()
        {
            if (Input.GetKey(KeyCode.D))
            {
                mainCharacterRigibody.velocity = new Vector2(runSpeed, mainCharacterRigibody.velocity.y);
                mainCharacterSpriteRenderer.flipX = false;
            }
            if (Input.GetKey(KeyCode.A))
            {
                mainCharacterRigibody.velocity = new Vector2(-runSpeed, mainCharacterRigibody.velocity.y);
                mainCharacterSpriteRenderer.flipX = true;
            }
            if (Input.GetKey(KeyCode.W))
            {
                mainCharacterRigibody.velocity = new Vector2(mainCharacterRigibody.velocity.x, runSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                mainCharacterRigibody.velocity = new Vector2(mainCharacterRigibody.velocity.x, -runSpeed);
            }
           
        }

        private void FixedUpdate()
        {
            Movement();
        }
    }
}
