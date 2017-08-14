using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{
    public class EnemySpawner : MonoBehaviour
    {
        delegate void SpawnFunc();

        public Transform target;
        public Transform spawnPoint;
        public GameObject orcPrefab;
        public GameObject trollPrefab;
        public float minAmount = 0, maxAmount = 20;
        public float spawnRate = 1f;
        private List<SpawnFunc> spawnFuncs = new List<SpawnFunc>();

        // Use this for initialization
        void Awake()
        {
            spawnFuncs.Add(SpawnTroll);
            spawnFuncs.Add(SpawnOrc);
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            int randomIndex = Random.Range(0, spawnFuncs.Count);
            spawnFuncs[randomIndex]();
        }

        /// <summary>
        /// goal is to call those two functions
        /// randomly using delegates
        /// </summary>
        void SpawnTroll()
        {
            //Spawn Troll Prefab
            GameObject clone = Instantiate(trollPrefab, spawnPoint.position, transform.rotation);
            //SetTarget on troll to target
            Enemy enemy = clone.GetComponent<Enemy>();
            enemy.SetTarget(target);
        }

        void SpawnOrc()
        {
            //Spawn Orc Prefab
            GameObject clone = Instantiate(orcPrefab, spawnPoint.position, transform.rotation);
            //SetTarget on Orc to target
            Enemy enemy = clone.GetComponent<Enemy>();
            enemy.target = target;
        }
    }
}
