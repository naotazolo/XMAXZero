using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody2D _body;
        public Animator anim;

        private bool _flipplayer = true;

        public bool isJumping;

        public Transform groundcheck;

        public LayerMask groundLayer;

        public bool isGrounded;


        private void Awake()
        {
            // grab references for rigidbody and animator form object
            _body = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {

            Debug.Log(isGrounded);
            var horizontalInput = Input.GetAxis("Horizontal");
            _body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, _body.velocity.y);
            // flip player when moving left-right
            if (horizontalInput > 0 && !_flipplayer)
                Flip();
            else if (horizontalInput < 0 && _flipplayer) Flip();

            isGrounded = Physics2D.OverlapCapsule(groundcheck.position, new Vector2(0.18f, 0.03f),
                CapsuleDirection2D.Horizontal, 0, groundLayer);

            //jump
            if (Input.GetKey(KeyCode.Space) && isGrounded)
                _body.velocity = new Vector2(_body.velocity.x, 2);
            isJumping = false;

            //set the animation parameters  
            anim.SetFloat("walk", MathF.Abs(horizontalInput));
        }

        //flipplayer
        private void Flip()
        {
            var currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;

            _flipplayer = !_flipplayer;
        }
    }
}