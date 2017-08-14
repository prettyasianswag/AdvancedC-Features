using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    public class Movement : MonoBehaviour
    {
        public float acceleration = 100f;
        public float hyperSpeed = 150f;
        private float rotationSpeed = 5f;

        [Tooltip("Deceleration for as a percentage of the current velocity")]
        [Range(0,1)] public float deceleration = 0.1f;

        private Rigidbody2D rigid;

        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            Accelerate();
            Decelerate();
            Rotate();
        }

        void Accelerate()
        {
            float inputV = Input.GetAxis("Vertical");
            Vector3 force = transform.right * inputV;

            // Check if left shift is pressed for hyperspeed
            if (Input.GetKey (KeyCode.LeftShift))
            {
                // Go hyperspeed!
                force *= hyperSpeed;
            }
            else
            {
                // Go regular speed
                force *= acceleration;
            }
            rigid.AddForce(force);
        }

        void Decelerate()
        {
            // velocity = -velocity * deceleration
            rigid.velocity += -rigid.velocity * deceleration;
        }

        void Rotate()
        {
            float inputH = Input.GetAxisRaw("Horizontal");
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed * inputH, Vector3.back);
        }
    }
}
