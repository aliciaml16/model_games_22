using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oa_project {
    public class bullet : MonoBehaviour
    {
        public Material mat;
        private Renderer[] children;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        // We make the bullets disappear
        void OnCollisionEnter(Collision col) {
            if(col.collider.gameObject.tag == "target")
            {
                Destroy(gameObject);
            } 
        }

        void OnTriggerEnter(Collider col) {
            // Reaction to teletubies
            if(col.gameObject.tag == "teletubi")
            {
                col.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = mat;
                col.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = mat;
            } 
        }
    }
}
