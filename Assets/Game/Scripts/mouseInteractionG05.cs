using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseInteractionG05 : MonoBehaviour
{
    private float timeBetween = 1;
    private float time = 0;
    private int whichPlatform = 1;
    public Material[] materials;
    public GameObject touchyCube;
    void Start()
    {
        
    }

    void Update()
    {
        // We add a counter to show a new object
        time += Time.deltaTime;
        if (time > timeBetween) {
            time = 0;
            GameObject cube;

            // Creates a new cube in each platform
            if (whichPlatform == 1) {
                cube = Instantiate(touchyCube, new Vector3(Random.Range(-6.52f, 5.67f), 6.52f, -11f), Quaternion.identity);
                whichPlatform = 2;
            } else if (whichPlatform == 2) {
                cube = Instantiate(touchyCube, new Vector3(11.0f, 6.52f, Random.Range(-7.45f, 6.09f)), Quaternion.identity);
                whichPlatform = 3;
            } else if (whichPlatform == 3) {
                cube = Instantiate(touchyCube, new Vector3(Random.Range(6.62f, -6.97f), 6.52f, 11f), Quaternion.identity);
                whichPlatform = 4;
            } else if (whichPlatform == 4) {
                cube = Instantiate(touchyCube, new Vector3(-11.0f, 6.52f, Random.Range(6.04f, -7f)), Quaternion.identity);
                whichPlatform = 1;
            } else {
                cube = Instantiate(touchyCube, new Vector3(Random.Range(-6.52f, 5.67f), 6.52f, -11f), Quaternion.identity);
            }

            Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>();

            // Mass
            gameObjectsRigidBody.mass = 0.5f;

            // Material
            int randomMaterial = Random.Range(0, materials.Length);
            cube.GetComponent<Renderer>().material = materials[randomMaterial];
        }

        // Jumping of the platforms
        RaycastHit hit;
        var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit) &&  hit.rigidbody != null) {
            if (hit.transform.gameObject.gameObject.tag == "ball") {
                hit.rigidbody.AddForce(new Vector3(5, 0, 0), ForceMode.Impulse);
            } else if (hit.transform.gameObject.gameObject.tag == "ball02"){
                hit.rigidbody.AddForce(new Vector3(0, 0, 5), ForceMode.Impulse);
            } else if (hit.transform.gameObject.gameObject.tag == "platform"){
                hit.rigidbody.AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);
            }
        }
    }
}
