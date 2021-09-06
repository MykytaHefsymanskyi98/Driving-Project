using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float turnSpeed = 300f;

    float moveSpeedDelta = 0.1f;
    int steerValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        SteerCar();
    }

    void MoveForward()
    {
        moveSpeed += moveSpeedDelta * Time.deltaTime;
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void SteerCar()
    {
        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
    }
    public void SetSteerValue(int value)
    {
        steerValue = value;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<Sceneloader>().LoadGameOver();
        }
    }
}
