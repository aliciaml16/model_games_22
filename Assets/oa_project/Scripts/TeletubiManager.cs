using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oa_project {
    public class TeletubiManager : MonoBehaviour
    {
        public GameObject teletubi;
        public int numberOfGames = 8;
        public int speed = 5;
        
        private GameObject[] allTeletubis;
        private List<Vector3> teletubiTarget = new List<Vector3>();

        void Start()
        {
            for (int i = 0 ; i < numberOfGames ; i++) {
                GameObject clone;
                clone = Instantiate(teletubi, new Vector3(Random.Range(-185f, 185f), 50, Random.Range(-185f, 185f)), transform.rotation * Quaternion.Euler (0f, 180f, 0f));
                teletubiTarget.Add(new Vector3(Random.Range(-185f, 185f), 40, Random.Range(-185f, 185f)));
            }
            allTeletubis = GameObject.FindGameObjectsWithTag("teletubi");
        }
        
        void Update()
        {
            var step =  speed * Time.deltaTime;
            for (int i = 0 ; i < allTeletubis.Length ; i++) {
                allTeletubis[i].transform.position = Vector3.MoveTowards(allTeletubis[i].transform.position, teletubiTarget[i], step);

                if (allTeletubis[i].transform.position == teletubiTarget[i]) {
                    teletubiTarget[i] = new Vector3(Random.Range(-185f, 185f), 40, Random.Range(-185f, 185f));
                }
            }
        }
    }
}