using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armyManager : MonoBehaviour
{
    public GameObject littleGuy;

    // Time variables
    private float timeToAppear = 0.01f;
    private int numberLittleGuy = 0;
    private float timer = 0.0f;

    // Movement Army
    private bool jumping = false;
    private GameObject[] army;

    async void Start()
    {

    }

    async void Update()
    {
        timer += Time.deltaTime;

        if (numberLittleGuy < 41 && timer > timeToAppear) {
            GameObject clone;
            clone = Instantiate(littleGuy, new Vector3(Random.Range(-43.0f, 43.0f), 7.64f, Random.Range(-43.0f, 43.0f)), Quaternion.identity);

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
