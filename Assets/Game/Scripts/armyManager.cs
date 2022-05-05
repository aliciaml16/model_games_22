using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armyManager : MonoBehaviour
{
    public GameObject littleGuy;
    public GameObject ballGO;

    // Time variables
    private float timeToAppear = 0.2f;
    private float timeToAppearBall = 0.2f;
    private int numberLittleGuy = 0;
    private float timer = 0.0f;
    private float timerBall = 0.0f;

    // Movement Army
    private GameObject[] army;
    private int slideNumber = 0;
    private int maxArmy = 15;
    public Material[] materials;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        timerBall += Time.deltaTime;
        if (timerBall > timeToAppearBall) {
            if (slideNumber == 0) {
                GameObject ball;
                ball = Instantiate(ballGO, new Vector3(-69f, 72.3f, Random.Range(-61f, -65f)), Quaternion.identity);
                int randomColour = Random.Range(0, materials.Length);
                ball.GetComponent<Renderer>().material = materials[randomColour];
                slideNumber = 1;
            } else if (slideNumber == 1) {
                GameObject ball;
                ball = Instantiate(ballGO, new Vector3(-69f, 72.3f, Random.Range(64f, 68f)), Quaternion.identity);
                int randomColour = Random.Range(0, materials.Length);
                ball.GetComponent<Renderer>().material = materials[randomColour];
                slideNumber = 0;
            }
            timerBall = 0;
        }

        if (numberLittleGuy < maxArmy && timer > timeToAppear) {
            createGuy();
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

    void createGuy() {
        GameObject clone;
        clone = Instantiate(littleGuy, new Vector3(Random.Range(-15.0f, 20.0f), 10f, Random.Range(-20.0f, 20.0f)), Quaternion.identity);
        numberLittleGuy += 1;
    }
}
