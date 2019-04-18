using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S6_ResponseHandler : MonoBehaviour
{

    public float[] scenarioResponses = new float[PARAMETERS.numberOfScenarios];

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
}
