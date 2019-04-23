using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseHandler : MonoBehaviour
{
    // Extra entry is Z Position!
    public float[] scenarioResponses = new float[PARAMETERS.numberOfScenarios + 1];
    public int[] directionResponses = { 0, 0, 0, 0, 0, 0 };

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < scenarioResponses.Length; i++)
        {
            scenarioResponses[i] = 999;
        }
    }

    public void WriteResponse(int index, float responseTime)
    {
        scenarioResponses[index] = responseTime * directionResponses[index];
    }

    public void WriteChosenPosition(float zPosition)
    {
        scenarioResponses[6] = zPosition;
    }
}
