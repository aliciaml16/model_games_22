using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace boundaries
{
    public class Deleter : MonoBehaviour
    {
        public GameObject deleterWall;
        public float deleteInterval = 40;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (Time.time > deleteInterval)
            {
                deleteInterval += 40f;
                Instantiate(deleterWall, new Vector3(40, 2.25f, 0f), Quaternion.Euler(0, 90, 0));
            }
        }
    }
}


