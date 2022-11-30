using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace boundaries
{
    public class DrawWall : MonoBehaviour
    {
        private bool creating;
        public GameObject start;
        public GameObject end;
        public GameObject wallPole;
        public Material newMaterial;
        public Material initBallMat;
        public Material newBallMat;


        // Start is called before the first frame update
        void Start()
        {
            Physics.IgnoreLayerCollision(6, 7, true);
            Physics.IgnoreLayerCollision(0, 6, false);
        }

        // Update is called once per frame
        void Update()
        {


            RaycastHit hit;
            var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButton(0))
            {
                if (Physics.Raycast(ray, out hit) && hit.rigidbody != null)
                {
                    if (hit.rigidbody.tag == "Ground")
                    {
                        //setStart();
                        createWall();
                    }
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (Physics.Raycast(ray, out hit) && hit.rigidbody != null)
                {
                    if (hit.rigidbody.tag == "Ball")
                    {
                        hit.rigidbody.tag = "Ball2";
                        hit.transform.GetComponent<MeshRenderer>().material = newBallMat;
                        hit.transform.gameObject.layer = 6;

                    }
                    else if (hit.rigidbody.tag == "Ball2")
                    {
                        hit.rigidbody.tag = "Ball";
                        hit.transform.GetComponent<MeshRenderer>().material = initBallMat;
                        hit.transform.gameObject.layer = 0;
                    }
                }
            }
            else if (creating)
            {
                //adjust();
            }




        }

        void createWall()
        {
            Instantiate(wallPole, getWorldPoint(), Quaternion.identity);
        }

        /*
        void setStart()
        {
            creating = true;
            //Instantiate(wallPole, getWorldPoint(), Quaternion.Euler(0, 0, 0));
        }
        void setEnd()
        {
            creating = false;
            //Instantiate(wallPole, getWorldPoint(), Quaternion.Euler(0, 0, 0));
        }
        void adjust()
        {
            Instantiate(wallPole, getWorldPoint(), Quaternion.Euler(0, 0, 0));

        }
        */

        Vector3 getWorldPoint()
        {
            RaycastHit hit;
            var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Ground")
            {
                return hit.point;
            }
            else return Vector3.zero;
        }

        void changeBall()
        {

        }


    }
}
