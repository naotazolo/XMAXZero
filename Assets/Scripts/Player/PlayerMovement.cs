using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField ] private float speed;
        private Rigidbody2D body;
        private Animator anim;

        private bool flipplayer = true;
        

        private void Awake()
        {
            // grab references for rigidbody and animator form object
            body = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        // flip player when moving left-right
        if (horizontalInput > 0 && !flipplayer)
        {
            flip();
        }
        else if (horizontalInput < 0 && flipplayer)
        {
            flip();
        }
        
        
        
        //jump
            if (Input.GetKey(KeyCode.Space))
                body.velocity = new Vector2(body.velocity.x, speed);
            
        //set the animation parameters  
           // anim.SetBool("walk", horizontalInput !=0 );
        }
        //flipplayer
        void flip()
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;

            flipplayer = !flipplayer;
        }
        
        
    }
}
