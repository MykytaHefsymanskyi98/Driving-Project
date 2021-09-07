using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float turnSpeed = 300f;

    float moveSpeedDelta = 0.1f;
    float timeDelay = 1f;
    int steerValue;
    bool ableToMove;

    // Start is called before the first frame update
    void Start()
    {
        ableToMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        SteerCar();
    }

    void MoveForward()
    {  
        if(ableToMove)
        {
            moveSpeed += moveSpeedDelta * Time.deltaTime;
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else { return; }
    }

    void SteerCar()
    {
        if(ableToMove)
        {
            transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
        }
        else { return; }
    }
    public void SetSteerValue(int value)
    {
        steerValue = value;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            StartCoroutine(ObstacleHitCoroutine());
        }
        if(collision.gameObject.tag =="Barrel")
        {
            StartCoroutine(BarrelHitCoroutine());
        }
    }

    IEnumerator ObstacleHitCoroutine()
    {
        RemoveCarControl();
        yield return new WaitForSeconds(timeDelay);
        FindObjectOfType<Sceneloader>().LoadGameOver();
    }
    IEnumerator BarrelHitCoroutine()
    {
        yield return new WaitForSeconds(timeDelay);
        FindObjectOfType<Sceneloader>().LoadGameOver();
    }

    void RemoveCarControl()
    {
        ableToMove = false;
    }
}
