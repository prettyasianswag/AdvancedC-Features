using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Bullet : MonoBehaviour
    {
        public float speed = 20f;
        public float aliveDistance = 5f;

        public Rigidbody2D rigid;
        // Position Fired From
        public Vector3 shotPos;

        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            shotPos = transform.position;
        }

        void Update()
        {

        }

        public abstract void Fire(Vector3 direction, float? speed = null);
    }
}
