using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class A
    {
        public abstract void AA();
    }
    
    
    
    
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed; 
        private Rigidbody2D _rigidbody2D;
        private Vector2 _movementDirection;
        private Action a;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            a += A;
        }

        private void A()
        {
            
        }

        private void Update()
        {

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            
            _movementDirection = new Vector2(x, y);
            
            a.Invoke();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = _movementDirection * movementSpeed;
        }
    }
}