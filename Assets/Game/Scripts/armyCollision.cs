using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armyCollision : MonoBehaviour
{
    public GameObject jumping;
    private float timer = 0.0f;
    private float timeToChange = 2.0f;
    private bool counting = false;
    void Start()
    {
        
    }

    void Update()
    {
    } 
    
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "floor")
        {
           jumping.transform.position = new Vector3(0, 0, 0);
        }
    }
}
