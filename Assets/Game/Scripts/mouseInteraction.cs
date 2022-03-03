using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseInteraction : MonoBehaviour
{
    public Material material00;
    public Material material01;
    public Material material02;
    public Material material03;
    public Material material04;
    public Material material05;

    private float randomMass;
    //var gabeObject cube00;
    void Start()
    {

    }

    void Update()
    {
        RaycastHit hit;

        var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        // If it hits but the object also has a rigidbody
        if (Physics.Raycast(ray, out hit) &&  hit.rigidbody != null) {
             if (Input.GetMouseButtonDown(0)){
                 hit.rigidbody.AddForce(new Vector3(20, 0, 0), ForceMode.Impulse);
             }
             if (Input.GetMouseButtonDown(2)){
                 hit.rigidbody.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
             }
             if (Input.GetMouseButtonDown(1)){
                 hit.rigidbody.AddForce(new Vector3(-20, 0, 0), ForceMode.Impulse);
             }
        }

        if (Input.GetKeyDown("space"))
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = new Vector3(Random.Range(0.0f, 10.0f), 2.5f, 0);

            Rigidbody gameObjectsRigidBody = sphere.AddComponent<Rigidbody>(); // Add the rigidbody.
            randomMass = Random.Range(2.0f, 3.5f);
            gameObjectsRigidBody.mass = randomMass; // Set the GO's mass to 5 via the Rigidbody.

            if(randomMass >= 2f && randomMass < 2.25f) {
                sphere.GetComponent<Renderer>().material = material00;
            } else if(randomMass >= 2.25f && randomMass < 2.5f) {
                sphere.GetComponent<Renderer>().material = material01;
            } else if(randomMass >= 2.5f && randomMass < 2.75f) {
                sphere.GetComponent<Renderer>().material = material02;
            } else if(randomMass >= 2.75f && randomMass < 3f) {
                sphere.GetComponent<Renderer>().material = material03;
            } else if(randomMass >= 3f && randomMass < 3.25f) {
                sphere.GetComponent<Renderer>().material = material04;
            } else if(randomMass >= 3.25f && randomMass < 3.5f) {
                sphere.GetComponent<Renderer>().material = material05;
            }
        }
    }
}
