using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    TrainMove train;
    Light light;
    ScenarioHandler scenarioHandler;

    public bool isTriggered = false;
    public float startTime, lerpSpeed;
    private Vector3 initialRot;

    // Start is called before the first frame update
    void Start()
    {
        scenarioHandler = GameObject.Find("ScenarioContainer").GetComponent<ScenarioHandler>();
        train = GameObject.Find("TrainControl").GetComponent<TrainMove>();
        light = GetComponent<Light>();

        initialRot = transform.eulerAngles;

        lerpSpeed = PARAMETERS.LightActivationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            float distCovered = (Time.time - startTime) * lerpSpeed;
            float fracJourney = distCovered / (PARAMETERS.LightEnd - PARAMETERS.LightStart);
            light.range = Mathf.Lerp(PARAMETERS.LightStart, PARAMETERS.LightEnd, fracJourney);
        }
    }

    public void TriggerLight()
    {
        isTriggered = true;

        if (PARAMETERS.directions[scenarioHandler.scenarioIndex] == 1)
        {
            transform.rotation = Quaternion.Euler(initialRot.x, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(180 - initialRot.x, 0, 0);
        }

        startTime = Time.time;
    }
}
