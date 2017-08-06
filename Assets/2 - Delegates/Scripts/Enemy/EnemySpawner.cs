using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{
    public class EnemySpawner : MonoBehaviour
    {
        public Transform target;
        public Transform[] spawnPoint;
        public GameObject[] enemyPrefab;

        // Update is called once per frame
        void Update()
        {
            StartCoroutine(SpawnEnemy());
        }

        public delegate void OnSpawn();
        public event OnSpawn onSpawn;

        private void Start()
        {

        }

        IEnumerator SpawnEnemy()
        {
            // Choosing a random spawnpoint to spawn a random enemyPrefab
            int spawn_num = Random.Range(0, spawnPoint.Length);

            // For every spawnpoint, spawn an enemy prefab randomly
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                // Choosing the enemy prefab to spawn
                int prefab_num = Random.Range(0, enemyPrefab.Length);
                // Spawning the chosen prefab
                Instantiate(enemyPrefab[prefab_num], spawnPoint[i].position, Quaternion.identity);
                // After 10 seconds, run the line of code again
                yield return new WaitForSeconds(1f);
            }

        }
    }
}
