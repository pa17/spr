using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    ResponseHandler response;
    ScenarioHandler scenarioHandler;
    
    public float timePassed = 0;
    public float timer = 0;

    void Start()
    {
        response = GameObject.Find("Response").GetComponent<ResponseHandler>();
        scenarioHandler = GetComponentInParent<ScenarioHandler>();
    }

    public void ResetTimer()
    {
        timer = timePassed;
    }

    public void StopTimer()
    {
        Debug.Log("The time taken until train perceived as passed: " + (timePassed - timer));

        ScenarioID name = scenarioHandler.scenarios[scenarioHandler.scenarioIndex].GetComponent<ScenarioID>();
        int id = name.scenarioID;

        // Write time taken to responses array. Multiplied by 1 if Left was chosen, by -1 if Right was chosen
        response.WriteResponse(id, timePassed - timer);
    }
    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
    }
}
