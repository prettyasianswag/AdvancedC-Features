using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Networking
{
    public class Player : MonoBehaviour
    {
        public float movementSpeed = 10.0f;
        public float rotationSpeed = 10.0f;
        public float jumpHeight = 2.0f;
        private bool isGrounded = false;
        private Rigidbody rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Move(float h, float v, float mh)
        {
            Vector3 position = rigid.position;
            Quaternion rotation = rigid.rotation;

            position += transform.forward * v * movementSpeed * Time.deltaTime;
          
            rotation *= Quaternion.AngleAxis(rotationSpeed * h, Vector3.up);

            position += transform.right * mh * movementSpeed * Time.deltaTime;
            
            rigid.MovePosition(position);
            rigid.MoveRotation(rotation);
        }

        public void Jump()
        {
            if (isGrounded)
            {
                rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                isGrounded = false;
            }
        }

        void OnCollisionEnter (Collision col)
        {
            isGrounded = true;
        }
    }
}

