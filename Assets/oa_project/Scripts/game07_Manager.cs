using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oa_project {
    public class game07_Manager : MonoBehaviour
    {
        public GameObject[] typeObjects;
        public int numberObjects = 10;

        private void Start()
        {
            for (int i = 0 ; i < numberObjects ; i++) {
                int randomNumber = Random.Range(0, typeObjects.Length);
                GameObject clone;
                clone = Instantiate(typeObjects[randomNumber], new Vector3(Random.Range(-2, 2), 1.5f, Random.Range(-2, 2)), Quaternion.identity);
            }
        }

        private void Update()
        {
            RaycastHit hit;
            var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) &&  hit.rigidbody != null) {
                Debug.Log(hit.rigidbody.tag);
                if (hit.rigidbody.tag == "object"){
                    hit.rigidbody.AddForce(new Vector3(Random.Range(-30, 30), Random.Range(-30, 30), Random.Range(-30, 30)), ForceMode.Impulse);
                } else if (hit.rigidbody.tag == "teletubi") {
                    if (Input.GetMouseButtonDown(0)){
                        hit.rigidbody.AddForce(new Vector3(0, 0, 1100), ForceMode.Impulse);
                    }
                }
            }
        }
    }
}
