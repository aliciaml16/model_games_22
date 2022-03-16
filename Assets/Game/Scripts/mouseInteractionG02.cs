using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseInteractionG02 : MonoBehaviour
{
    public Transform ballT;
    public Material[] materials;
    private int randomMaterial;
    private int numberObjects = 20;

    void Start(){}

    void FixedUpdate()
    {

        RaycastHit hit;

        var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        // If it hits but the object also has a rigidbody
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 dir = hit.point - ballT.position;
            ballT.GetComponent<Rigidbody>().AddForce(dir * 2);
            //hit.rigidbody.AddForce(new Vector3(1, 0 , 1), ForceMode.Impulse);
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0 ; i < numberObjects ; i++) {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(Random.Range(-13.0f, 13.0f), 10.0f, Random.Range(-13.0f, 13.0f));
                Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>();
                BoxCollider gameObjectsCollider = cube.AddComponent<BoxCollider>();

                float randomMass = Random.Range(2.0f, 3.5f);
                gameObjectsRigidBody.mass = randomMass;

                randomMaterial = Random.Range(0, materials.Length);
                cube.GetComponent<Renderer>().material = materials[randomMaterial];

                cube.gameObject.tag="collisionable";
            }
        }
    }
}
