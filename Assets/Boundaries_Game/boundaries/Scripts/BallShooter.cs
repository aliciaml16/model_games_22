using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace boundaries
{

    public class BallShooter : MonoBehaviour
    {

        Rigidbody thisBall;
        public float initThrust = 10f;
        public float wallThrust = 5f;
        public float maxSpeed = 10f;



        // Start is called before the first frame update
        void Start()
        {
            thisBall = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {


        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "spawnWall")
            {
                thisBall.AddForce(new Vector3(1, 0, -1) * initThrust, ForceMode.Impulse);
            }

            if (collision.gameObject.tag == "Wall" && Mathf.Abs(thisBall.velocity.x) < maxSpeed && Mathf.Abs(thisBall.velocity.y) < maxSpeed && Mathf.Abs(thisBall.velocity.z) < maxSpeed)
            {
                thisBall.AddForce(collision.contacts[0].normal * wallThrust, ForceMode.Impulse);

                //-thisBall.transform.forward
            }
        }
    }
}
