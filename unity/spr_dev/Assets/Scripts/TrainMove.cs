using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;
    GameObject trainContainer;
    Transform trainLightTop, trainLightBottom, trainLightDirectional;

    private bool isHiding = false;

    public float activeTrainDistance;

    private Vector3 initialPosition;
    private Vector3 trainLightBottomRot, trainLightTopRot, trainLightDirectionalRot;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        trainContainer = GameObject.Find("TrainContainer");
        trainLightBottom = GameObject.Find("TrainLightBottom").GetComponent<Transform>();
        trainLightTop = GameObject.Find("TrainLightTop").GetComponent<Transform>();
        trainLightDirectional = GameObject.Find("TrainLightDirectional").GetComponent<Transform>();

        //transform.position = new Vector3(0, 0, PARAMETERS.TrainStartDistance);

        initialPosition = transform.position;
        trainLightBottomRot = trainLightBottom.eulerAngles;
        trainLightTopRot = trainLightTop.eulerAngles;
        trainLightDirectionalRot = trainLightDirectional.eulerAngles;
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

        if (direction == 1)
        {
            trainLightBottom.rotation = Quaternion.Euler(trainLightBottomRot);
            trainLightTop.rotation = Quaternion.Euler(trainLightTopRot);
            trainLightDirectional.rotation = Quaternion.Euler(trainLightDirectionalRot);
        }
        else
        {
            trainLightBottom.rotation = Quaternion.Euler(180 - trainLightBottomRot.x, trainLightBottomRot.y, trainLightBottomRot.z);
            trainLightTop.rotation = Quaternion.Euler(180 - trainLightTopRot.x, trainLightTopRot.y, trainLightTopRot.z);
            trainLightDirectional.rotation = Quaternion.Euler(180 - trainLightDirectionalRot.x, trainLightDirectionalRot.y, trainLightDirectionalRot.z);
        }
    }

    public void DisableLights()
    {
        trainLightBottom.gameObject.SetActive(false);
        trainLightTop.gameObject.SetActive(false);
    }
}
