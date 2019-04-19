using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S6_TrainAlteredHandler : MonoBehaviour
{
    public GameObject[] alteredTrains;
    public int alteredTrainIndex;

    // Start is called before the first frame update
    void Start()
    {
        alteredTrains = GameObject.FindGameObjectsWithTag("AlteredTrain");
        alteredTrainIndex = 0;

        // Switch to the first one upon boot
        SwitchAlteredTrains();
    }

    public void SwitchAlteredTrains()
    {
        int loopCounter = 0;
        foreach (GameObject train in alteredTrains)
        {
            if (alteredTrainIndex == loopCounter)
            {
                train.SetActive(true);
            }

            else
            {
                train.SetActive(false);
            }
            loopCounter += 1;
        }

        alteredTrainIndex += 1;

        if (alteredTrainIndex == alteredTrains.Length)
        {
            alteredTrainIndex = 0;
        }
    }
}
