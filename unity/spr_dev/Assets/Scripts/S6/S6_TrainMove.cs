using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S6_TrainMove : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;
    S6_TrainHandler trainHandler;

    private bool isHiding = false;


    private Vector3 initialPosition;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        trainHandler = GameObject.Find("S6_TrainContainer").GetComponent<S6_TrainHandler>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            rigidBody.AddRelativeForce(Vector3.back);
        }

        else if (Input.GetKey(KeyCode.K))
        {
            rigidBody.AddRelativeForce(Vector3.forward);
        }

        else if (Input.GetKey(KeyCode.C))
        {
            rigidBody.velocity = new Vector3(0, 0, -10);
        }

        else if (Input.GetKey(KeyCode.V))
        {
            rigidBody.velocity = new Vector3(0, 0, -20);
        }

        else if (Input.GetKey(KeyCode.B))
        {
            rigidBody.velocity = new Vector3(0, 0, -35);
        }

        trainHandler.activeTrainDistance = transform.position.z;
    }

    public void Accelerate()
    {
        rigidBody.velocity = new Vector3(0, 0, -20);
    }

    public void HideTrain()
    {
        gameObject.SetActive(false);
        Debug.Log("Hiding Train...");
    }

    public void ResetTrainPosition()
    {
        transform.position = initialPosition;
        rigidBody.velocity = new Vector3(0, 0, 0);
    }

    public void StopTrain()
    {
        rigidBody.velocity = new Vector3(0, 0, 0);
    }
}
