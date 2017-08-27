using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Plasma : Bullet
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float distance = Vector3.Distance(shotPos, transform.position);
            if (distance > aliveDistance)
            {
                Destroy(gameObject);
            }
        }

        public override void Fire(Vector3 direction, float? speed = null)
        {
            // Set currentSpeed to the member speeed
            float currentSpeed = this.speed;
            // If the optional argument has been set
            if (speed != null)
            {
                // Replace currentSpeed with the argument
                currentSpeed = speed.Value;
            }
            // Add force in the direction and currentSpeed
            rigid.AddForce(direction * currentSpeed, ForceMode2D.Impulse);
        }
    }
}

