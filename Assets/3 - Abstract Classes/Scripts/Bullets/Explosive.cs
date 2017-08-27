using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Explosive : Bullet
    {
        public GameObject explosionAnimation;

        public int explosionDamage = 100;
        public float explosionRadius = 5f;

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

        public void Explode()
        {
            // Instantiate the animation
            Instantiate(explosionAnimation, transform.position, transform.rotation);
            // Explosion damage can be used to subtract from enemy health when we implement it
            // Using explosion radius
            Destroy(gameObject);
        }

        public void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                Explode();
            }
        }
    }
}
