using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{
    public class EnemySpawner : MonoBehaviour
    {
        public enum Spawn
        {
            ORC = 0,
            TROLL = 1
        }
        delegate void SpawnFunc();

        public Transform target;
        public GameObject orcPrefab;
        public GameObject trollPrefab;
        public float minAmount = 0, maxAmount = 20;
        public float spawnRate = 1f;

        private List<SpawnFunc> spawnFuncs = new List<SpawnFunc>();
        public Spawn spawnIndex = Spawn.TROLL;

        // Use this for initialization
        void Awake()
        {
            spawnFuncs.Add(SpawnTroll);
            spawnFuncs.Add(SpawnOrc);
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            spawnFuncs[(int)spawnIndex]();
        }

        /// <summary>
        /// goal is to call those two functions
        /// randomly using delegates
        /// </summary>
        void SpawnTroll()
        {
            //Spawn Troll Prefab
            Instantiate(trollPrefab, transform.position, transform.rotation);
            //SetTarget on troll to target
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void SpawnOrc()
        {
            //Spawn Orc Prefab
            Instantiate(orcPrefab, transform.position, transform.rotation);
            //SetTarget on Orc to target
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
