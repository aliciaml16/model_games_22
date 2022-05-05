using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armyCollision : MonoBehaviour
{
    public GameObject littleGuy;
    public GameObject jumping;
    public Material redMaterial;

    // Dead guy variables    
    private int numberDeadGuy = 0;
    private int maxDeadGuy = 10;
    private int numberGuysExplosion = 200;
    void Start()
    {
        
    }

    void Update()
    {
    } 
    
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "armyCollision")
        {
            GameObject body = collision.transform.parent.gameObject;
            GameObject guy = body.transform.parent.gameObject;
            GameObject head = guy.transform.GetChild(1).gameObject;

            // Destroy the Scripts
            Destroy(body.GetComponent<RandomMovement>());
            Destroy(head.GetComponent<hit>());
            Destroy(head.GetComponent<colors>());

            // Change material to red
            body.GetComponent<Renderer>().material = redMaterial;
            head.GetComponent<Renderer>().material = redMaterial;

            // Destroy collision detectors
            int children = body.transform.childCount;
            for (int i = 0; i < children; ++i){
                GameObject child = body.transform.GetChild(i).gameObject;
                Destroy(child);
            }

            // Dead guys counter
            numberDeadGuy = numberDeadGuy + 1;
            Debug.Log(numberDeadGuy);

            createGuy();

            if (numberDeadGuy == maxDeadGuy) {
                for (int i = 0 ; i < numberGuysExplosion ; i++) {
                    createGuy();
                }
                numberDeadGuy = 0;
            }
        }
    }
    void createGuy() {
        GameObject clone;
        clone = Instantiate(littleGuy, new Vector3(Random.Range(-15.0f, 20.0f), 10f, Random.Range(-20.0f, 20.0f)), Quaternion.identity);
    }
}
