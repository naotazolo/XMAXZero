using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed;
        public float jump;

        private float Move;

        public Rigidbody2D rb;
    
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update()
        {
            Move = Input.GetAxis("Horizontal");

            rb.velocity = new Vector2(speed * Move, rb.velocity.y);
        }
    }
}
