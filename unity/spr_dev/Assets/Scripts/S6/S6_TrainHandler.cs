using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S6_TrainHandler : MonoBehaviour
{

    public S6_TrainMove[] trainsMove;
    public float hideTrainDistance = PARAMETERS.HideTrainDistance;

    public GameObject[] trains;
    public int trainsIndex;
    public float activeTrainDistance;

    // Start is called before the first frame update
    void Start()
    {
        trainsMove = GetComponentsInChildren<S6_TrainMove>(true);

        trains = GameObject.FindGameObjectsWithTag("Train");
        trainsIndex = 0;

        activeTrainDistance = 0;

        // Switch to the first one upon boot
        SwitchTrains();
    }

    public void SwitchTrains()
    {
        int loopCounter = 0;
        foreach (GameObject train in trains)
        {
            if (trainsIndex == loopCounter)
            {
                train.SetActive(true);
            }

            else
            {
                train.SetActive(false);
            }
            loopCounter += 1;
        }

        trainsIndex += 1;

        if (trainsIndex == trains.Length)
        {
            trainsIndex = 0;
        }
    }

    public void AccelerateTrains()
    {
        foreach (S6_TrainMove train in trainsMove)
        {
            if (train.gameObject.activeSelf == true)
            {
                // train.Accelerate();
            }
        }
    }
    
    public void StopTrains()
    {
        foreach (S6_TrainMove train in trainsMove)
        {
            if (train.gameObject.activeSelf == true)
            {
                train.StopTrain();
            }
        }
    }

    public void ResetTrainPositions()
    {
        foreach (S6_TrainMove train in trainsMove)
        {
            if (train.gameObject.activeSelf == true)
            {
                // train.ResetTrainPosition();
            }
        }
    }

    public void HideTrains()
    {
        foreach (S6_TrainMove train in trainsMove)
        {
            if (train.gameObject.activeSelf == true)
            {
                train.HideTrain();
            }
        }
    }
}
