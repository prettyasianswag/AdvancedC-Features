using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    public class PulseCannon : Weapon
    {
        public float shootRadius = 10f;

        public override void Fire()
        {
            Bullet b = SpawnBullet(transform.position, transform.rotation);
            Vector3 direction = transform.up;
            b.aliveDistance = shootRadius;
            b.Fire(direction);
        }
    }
}
