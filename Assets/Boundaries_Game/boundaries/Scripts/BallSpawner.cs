using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace boundaries
{
    public class BallSpawner : MonoBehaviour
    {

        public float spawnTime = 10f;
        public Object ballPrefab;
        public GameObject spawnPos;


        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnBalls(i);
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time > spawnTime)
            {
                spawnTime += 10f;
                for (int i = 0; i < 6; i++)
                {
                    SpawnBalls(i);
                }
            }
        }



        void SpawnBalls(int counter)
        {
            Vector3 spawnHere = spawnPos.transform.position + new Vector3(counter % 2 * 2, counter * 3f, 0);
            Instantiate(ballPrefab, spawnHere, Quaternion.Euler(0, 0, 0));
        }
    }
}
