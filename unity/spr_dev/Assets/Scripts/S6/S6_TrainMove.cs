using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S6_TrainMove : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;
    GameObject trainContainer;

    private bool isHiding = false;

    public float activeTrainDistance;

    private Vector3 initialPosition;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        trainContainer = GameObject.Find("S6_TrainContainer");
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

        activeTrainDistance = transform.position.z;
    }

    public void Accelerate(float direction)
    {
        rigidBody.velocity = new Vector3(0, 0, direction * PARAMETERS.TrainSpeed);
    }

    public void HideTrain()
    {
        gameObject.SetActive(false);
        Debug.Log("Hiding Train...");
    }

    public void ResetTrainPosition(int direction)
    {
        transform.position = new Vector3 (initialPosition.x, initialPosition.y, direction * initialPosition.z);
        rigidBody.velocity = new Vector3(0, 0, 0);
    }

    public void StopTrain()
    {
        rigidBody.velocity = new Vector3(0, 0, 0);
    }

    public void SwitchDirection(int direction)
    {
        trainContainer.transform.localScale = new Vector3(1, 1, direction);
    }
}
