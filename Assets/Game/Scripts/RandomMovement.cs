using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class RandomMovement : MonoBehaviour {
 
    private bool selectNewRandomPosition = true;
    private bool waitingForNewPosition = false;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float movementSpeed;
    public float newPositionWaitTime;
    private float moveX;
    private float moveY;
    private float newX;
    private float newY;
    private float stopX;
    private float stopY;
    private float frameX;
    private float frameY;
    private float movedX;
    private float movedY;
    public GameObject jumping;
    // Update is called once per frame
    void Start() {
        jumping.transform.position = new Vector3(0, 0, 0);
    }
    void Update() {
        Debug.Log(jumping.transform.position.z);
        if (jumping.transform.position.z == 1) {
            if (selectNewRandomPosition) {
                StartCoroutine(newRandomPosition());
            } else if (!waitingForNewPosition) {
                frameX = (moveX * Time.deltaTime * movementSpeed);
                frameY = (moveY * Time.deltaTime * movementSpeed);
                movedX += frameX;
                movedY += frameY;
                newX = this.transform.position.x + frameX;
                newY = this.transform.position.y + frameY;
                if (Mathf.Abs(movedY) >= Mathf.Abs(moveX) || Mathf.Abs(movedY) >= Mathf.Abs(moveY)) {
                    waitingForNewPosition = true;
                    selectNewRandomPosition = true;
                } else {
                    this.transform.position = new Vector3(newX, newY, this.transform.position.z);
                }
            }
        }
        if (Input.GetMouseButtonDown(0)){
            jumping.transform.position = new Vector3(0, 0, 1);
        }
    }
    
 
    IEnumerator newRandomPosition() {
        waitingForNewPosition = true;
        selectNewRandomPosition = false;
        yield return new WaitForSeconds(newPositionWaitTime);
        moveX = Random.Range(minX, maxX);
        moveY = Random.Range(minY, maxY);
        stopX = this.transform.position.x + moveX;
        stopY = this.transform.position.y + moveY;
        movedX = 0f;
        movedY = 0f;
        waitingForNewPosition = false;
    }
}