using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainHandler : MonoBehaviour
{

    public TrainMove[] trainsMove;
    public int hideTrainDistance = 50;

    // Start is called before the first frame update
    void Start()
    {
        trainsMove = GetComponentsInChildren<TrainMove>(true);
    }

    public void AccelerateTrains()
    {
        foreach (TrainMove train in trainsMove)
        {
            if (train.gameObject.activeSelf == true)
            {
                train.Accelerate();
            }
        }
    }
    
    public void StopTrains()
    {
        foreach (TrainMove train in trainsMove)
        {
            if (train.gameObject.activeSelf == true)
            {
                train.StopTrain();
            }
        }
    }

    public void ResetTrainPositions()
    {
        foreach (TrainMove train in trainsMove)
        {
            if (train.gameObject.activeSelf == true)
            {
                train.ResetTrainPosition();
            }
        }
    }

    public void HideTrains()
    {
        foreach (TrainMove train in trainsMove)
        {
            if (train.gameObject.activeSelf == true)
            {
                train.HideTrain();
            }
        }
    }
}
