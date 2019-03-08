using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainHandler : MonoBehaviour
{

    public S6_TrainMove[] trainsMove;
    public int hideTrainDistance = 50;

    // Start is called before the first frame update
    void Start()
    {
        trainsMove = GetComponentsInChildren<S6_TrainMove>(true);
    }

    public void AccelerateTrains()
    {
        foreach (S6_TrainMove train in trainsMove)
        {
            if (train.gameObject.activeSelf == true)
            {
                train.Accelerate();
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
                train.ResetTrainPosition();
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
