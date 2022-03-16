using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shpereManager : MonoBehaviour
{
    public Material material00;
    public GameObject sphereExplosion;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "collisionable")
        {
            collision.gameObject.GetComponent<Renderer>().material = material00;
        }
    }

    public float radius = 20.0F;
    public float power = 1000000000.0F;

    void Update()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }
}
