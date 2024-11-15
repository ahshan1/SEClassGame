using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.UIElements;


namespace Platformer.Mechanics
{
    public class PlayerMovementScript : MonoBehaviour
    {
        // Max Horizontal Speed of character
        public float maxSpeed = 7;

        // Max Horziontal Speed of 
        public float jumpTakeOffSpeed = 7;

        // Can character be controlled. 
        public bool controlEnabled = true;

        // rigidbody of character 
        public Rigidbody2D rigidbody2d;

        // moveInputs for the character in both directions.
        public float moveInputX;
        public float moveInputY;

        public bool grounded = false;

        public BoxCollider2D groundCheck; // need to pick your characters ground collider

        public LayerMask groundMask; // Need to pick the layer you want from the inspector menu

        public Animator animator; // Need to pick the animator in the inspector menu

        // Start is called before the first frame update
        void Start()
        {
            //getting the rigid body of the character its attaced to when game starts. 


           rigidbody2d = GetComponent<Rigidbody2D>();

           animator = GetComponentInChildren<Animator>();



        }

        // Update is called once per frame
        void Update()
        {
            // need to seperate the inputs for P1 AND P2. 
            if (controlEnabled)
            {

                // gets numbers from the horizontal and vertical input keys. Every time a horizontal key is pressed it gets a value of 1 or -1
                moveInputX = Input.GetAxisRaw("Horizontal");

                if (moveInputX == -1)
                {
                    
                    // if the a key is pressed then it will "flip" the character to the left.
                    transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
                }
                else if (moveInputX == 1)
                {
                    //facing right
                    transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                }



                // changes a parameter in the animator called Speed. 
                animator.SetFloat("Speed",Mathf.Abs(moveInputX));


                // updates the position of the character by multiplying its vector components.
                rigidbody2d.velocity = new Vector2(moveInputX * maxSpeed, rigidbody2d.velocity.y);





                

                if (grounded == true)
                {

                    
                    // jump logic - animation is work in process. 
                    moveInputY = Input.GetAxisRaw("Vertical");

                    if (moveInputY > 0)
                    {
                        // setting a trigger for jump when the up arrow is pressed.
                        animator.SetTrigger("Jump");
                    }

                    rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, moveInputY*jumpTakeOffSpeed);

                 
                }


            }
            else
            {
                moveInputX = 0;
            }


            checkGrounded();

           
    
        }


       

        void checkGrounded()
        {
            grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min,groundCheck.bounds.max, groundMask).Length>0;
        }


       


    }




}