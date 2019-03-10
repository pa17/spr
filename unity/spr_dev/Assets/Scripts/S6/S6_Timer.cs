using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S6_Timer : MonoBehaviour
{
    S6_ResponseHandler response;
    S6_ScenarioHandler scenarioHandler;
    
    public float timePassed = 0;
    public float timer = 0;

    void Start()
    {
        response = GameObject.Find("Response").GetComponent<S6_ResponseHandler>();
        scenarioHandler = GetComponentInParent<S6_ScenarioHandler>();
    }

    public void ResetTimer()
    {
        timer = timePassed;
    }

    public void StopTimer()
    {
        Debug.Log("The time taken until train perceived as passed: " + (timePassed - timer));

        // Write time taken to responses array. Minus one because the index is already incremented at the time you press space.
        response.scenarioResponses[scenarioHandler.scenarioIndex - 1] = timePassed - timer;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;


    }
}
