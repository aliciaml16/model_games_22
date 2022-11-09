using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunManager : MonoBehaviour
{

    // Camera m_camera;

    // void Start()
    // {
    //     m_camera = Camera.main;  // Don't keep calling Camera.main
    // }
 
    // void Update()
    // {
    //     var lookAtPos = Input.mousePosition;
    //     lookAtPos.z = transform.position.z - m_camera.transform.position.z;
    //     lookAtPos = m_camera.ScreenToWorldPoint(lookAtPos);
    //     transform.up = lookAtPos - transform.position;
    // }

    public Camera camera;

    void Update()
    {
        // var lookPos = Input.mousePosition - transform.position;
        // lookPos.z = 0;
        // var rotation = Quaternion.LookRotation(lookPos);
        // transform.rotation = Quaternion.Slerp(transform.rotation.y, rotation.y, Time.deltaTime * 5f);

        //var ray = camera.ScreenPointToRay(Input.mousePosition);
        //transform.LookAt(new Vector3(ray.origin.x, ray.direction.y, ray.origin.z));
        // transform.LookAt(new Vector3(ray.direction.x, ray.direction.y, ray.direction.z));
    }


    // public float force;
    // public GameObject bulletPrefab;
    // public GameObject gunEnd;
    // private Vector3 aim;
    // // Update is called once per frame
    // void Update()
    // {
    //     Vector3 mousePos = Input.mousePosition;
    //     mousePos += Camera.main.transform.forward * 10f;
    //     aim = Camera.main.ScreenToWorldPoint(mousePos);
    //     gunEnd.transform.LookAt(aim);
        
    //     if (Input.GetKey(KeyCode.Mouse0)  )
    //     {
    //         GameObject bullet = Instantiate(bulletPrefab, gunEnd.transform.position, Quaternion.identity);
    //         bullet.transform.LookAt(aim);
    //         Rigidbody b = bullet.GetComponent<Rigidbody>();
    //         b.AddRelativeForce(Vector3.forward * force);
           
    //     }
    // }
}
