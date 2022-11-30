using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace boundaries
{
    public class deleteMe : MonoBehaviour
    {


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Deleter" && this.gameObject.tag != "Ball2")
            {
                GameObject.Destroy(this.gameObject);
            }
        }

    }
}
