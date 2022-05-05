using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseInteractionG04 : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        RaycastHit hit;

        var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        // If it hits but the object also has a rigidbody
        if (Physics.Raycast(ray, out hit) &&  hit.rigidbody != null) {
            if (hit.rigidbody.tag == "army") {
                if (Input.GetMouseButtonDown(0)){
                    hit.rigidbody.AddForce(new Vector3(0, 0, -1100), ForceMode.Impulse);
                }
            }
        }
    }
}
