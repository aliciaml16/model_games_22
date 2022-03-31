using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armyManager : MonoBehaviour
{
    public GameObject littleGuy;

    // Time variables
    private float timeToAppear = 1f;
    private float timeToAppearBall = 0.5f;
    private int numberLittleGuy = 0;
    private float timer = 0.0f;
    private float timerBall = 0.0f;

    // Movement Army
    private bool jumping = false;
    private GameObject[] army;
    private int slideNumber = 0;
    private int maxArmy = 20;
    private int maxBalls = 200;
    private int ballBatch = 5;
    public Material[] materials;
    private int numberBalls = 0;

    async void Start()
    {

    }

    async void Update()
    {
        timer += Time.deltaTime;
        timerBall += Time.deltaTime;
        if (numberBalls < maxBalls && timerBall > timeToAppearBall) {
            if (slideNumber == 0) {
                GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                int randomColour = Random.Range(0, materials.Length);
                ball.transform.position = new Vector3(-90.9f, 53.2f, -72.1f);
                ball.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
                Rigidbody gameObjectsRigidBody = ball.AddComponent<Rigidbody>();
                ball.GetComponent<Renderer>().material = materials[randomColour];
                slideNumber = 1;
            } else if (slideNumber == 1) {
                GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                int randomColour = Random.Range(0, materials.Length);
                ball.transform.position = new Vector3(-77.7f, 53.2f, 80.6f);
                ball.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
                Rigidbody gameObjectsRigidBody = ball.AddComponent<Rigidbody>();
                ball.GetComponent<Renderer>().material = materials[randomColour];
                slideNumber = 0;
            }
        }

        if (numberLittleGuy < maxArmy && timer > timeToAppear) {
            GameObject clone;
            // if (slideNumber == 0) {
            //     clone = Instantiate(littleGuy, new Vector3(-70.5f, 78f, 0f), Quaternion.identity);
            //     clone.transform.Rotate(0.0f, 0.0f, 30.0f, Space.Self);
            //     slideNumber = 1;
            // } else if (slideNumber == 1) {
            //     clone = Instantiate(littleGuy, new Vector3(-10.3f, 78f, 78.4f), Quaternion.identity);
            //     clone.transform.Rotate(0.0f, 90.0f, 30.0f, Space.Self);
            //     slideNumber = 2;
            // } else if (slideNumber == 2) {
            //     clone = Instantiate(littleGuy, new Vector3(24.6f, 78f, 78.4f), Quaternion.identity);
            //     clone.transform.Rotate(0.0f, 90.0f, 30.0f, Space.Self);
            //     slideNumber = 3;
            // } else if (slideNumber == 3) {
            //     clone = Instantiate(littleGuy, new Vector3(24.6f, 78f, -78.4f), Quaternion.identity);
            //     clone.transform.Rotate(0.0f, -90.0f, 30.0f, Space.Self);
            //     slideNumber = 4;
            // } else if (slideNumber == 4) {
            //     clone = Instantiate(littleGuy, new Vector3(-10.3f, 78f, -78.4f), Quaternion.identity);
            //     clone.transform.Rotate(0.0f, -90.0f, 30.0f, Space.Self);
            //     slideNumber = 0;
            // }

            clone = Instantiate(littleGuy, new Vector3(Random.Range(-27.0f, 40.0f), 7.9f, Random.Range(-27.0f, 27.0f)), Quaternion.identity);

            numberLittleGuy += 1;
            timer = 0;
        }

        RaycastHit hit;
        var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) &&  hit.rigidbody != null) {
             if (Input.GetMouseButtonDown(0)){
                 hit.rigidbody.AddForce(new Vector3(-20, 0, 0), ForceMode.Impulse);
             }
        }
    }
}
