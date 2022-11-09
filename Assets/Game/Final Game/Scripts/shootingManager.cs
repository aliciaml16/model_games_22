using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingManager : MonoBehaviour
{
    public GameObject bullet;
    public GameObject endGun;
    public GameObject gun;
    public Camera camera;
    public float force;

    private float movement = 3;

    private GameObject[] allBullets;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // We throw the bullets
        RaycastHit hit;
        var ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)){
            GameObject clone;
            clone = Instantiate(bullet, new Vector3(endGun.transform.position.x, endGun.transform.position.y, endGun.transform.position.z), transform.rotation * Quaternion.Euler (0f, 0f, 0f));
            clone.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, force, 0), ForceMode.Impulse);
            clone.tag = "bullet";
        }
        
        // We move the gun
        gun.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -movement, 0, Input.GetAxis("Mouse X") * -movement));
    }
}
