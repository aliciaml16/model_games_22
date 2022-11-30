using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace boundaries
{
    public class wallMover : MonoBehaviour
    {
        public float speed = 10.0f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-40f, 2.25f, 0.0f), step);

            // Check if the position of the cube and sphere are approximately equal.
            if (transform.position.x < -40)
            {
                // Swap the position of the cylinder.
                //target.position *= -1.0f;
                GameObject.Destroy(this.gameObject);
            }

        }
    }
}
