using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColour : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            collision.gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        }
    }
}
