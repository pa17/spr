using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S6_Timer : MonoBehaviour
{
    S6_ResponseHandler response;
    S8_ScenarioHandler scenarioHandler;
    
    public float timePassed = 0;
    public float timer = 0;

    void Start()
    {
        response = GameObject.Find("Response").GetComponent<S6_ResponseHandler>();
        scenarioHandler = GetComponentInParent<S8_ScenarioHandler>();
    }

    public void ResetTimer()
    {
        timer = timePassed;
    }

    public void StopTimer()
    {
        Debug.Log("The time taken until train perceived as passed: " + (timePassed - timer));

        // Write time taken to responses array. Multiplied by 1 if Left was chosen, by -1 if Right was chosen
        response.WriteResponse(scenarioHandler.scenarioIndex, timePassed - timer);
    }
    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
    }
}
