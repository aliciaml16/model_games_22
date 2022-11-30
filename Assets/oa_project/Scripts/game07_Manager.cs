using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace oa_project {
    public class game07_Manager : MonoBehaviour
    {
        [Header("TOYS FOR POOL")]
        public GameObject[] prefabObject;
        public int numberObjects = 10;
        public Material material;

        [Header("ALIENS")]
        public GameObject[] prefabAliens;
        public string[] nameScene;

        private void Start()
        {
            // for (int i = 0 ; i < prefabAliens.Length ; i++) {
            //     GameObject clone;
            //     clone = Instantiate(prefabAliens[i], new Vector3(Random.Range(-1.5f, 1.5f), 0.6f, Random.Range(-1.5f, 1.5f)), transform.rotation * Quaternion.Euler (0f, 180f, 0f));
            // }

            for (int i = 0 ; i < numberObjects ; i++) {
                int randomNumber = Random.Range(0, prefabObject.Length);
                GameObject clone;
                clone = Instantiate(prefabObject[randomNumber], new Vector3(Random.Range(-2, 2), 1.5f, Random.Range(-2, 2)), Quaternion.identity);
            }
        }

        private void Update()
        {
            RaycastHit hit;
            var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) &&  hit.rigidbody != null) {
                if (Input.GetMouseButton(0)){
                    if (hit.rigidbody.tag == "object"){
                        hit.rigidbody.AddForce(new Vector3(Random.Range(-40, 40), Random.Range(-40, 40), Random.Range(-40, 40)), ForceMode.Impulse);
                        //for (int i = 0 ; i < hit.getChild().Length ; i++) {
                            //hit.transform.gameObject.GetChild(i).GetComponent<MeshRenderer>().material = material[0];
                        //}
                    } 
                }

                if (Input.GetMouseButtonDown(0)){
                    if (hit.rigidbody.tag == "teletubi") {
                        hit.rigidbody.AddForce(new Vector3(0, 0, 1100), ForceMode.Impulse);
                        //SceneManager.LoadScene(nameScene[0], LoadSceneMode.Single);
                    }
                }
            }
        }
    }
}
