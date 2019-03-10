using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S6_ResponseHandler : MonoBehaviour
{

    public float[] scenarioResponses = new float[6];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < scenarioResponses.Length; i++)
        {
            scenarioResponses[i] = 999;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
