using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;
    MeshRenderer meshRenderer;

    private Vector3 initialPosition;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddRelativeForce(Vector3.back);
        }

        else if (Input.GetKey(KeyCode.S))
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
    }

    public void Accelerate()
    {
        rigidBody.velocity = new Vector3(0, 0, -20);
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
