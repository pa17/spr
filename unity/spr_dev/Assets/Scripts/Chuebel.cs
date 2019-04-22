using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chuebel : MonoBehaviour
{
    TrainMove train;
    Light light;
    ScenarioHandler scenarioHandler;

    public bool controlOrientation, controlIntensity;
    private float linearGain, logGain;
    public bool isTriggered = false;

    // Maximum turn rate in degrees per second.
    public float turningRate = 90f;
    // Rotation we should blend towards.
    private Quaternion _targetRotation = Quaternion.Euler(30, 0, 0);

    public float startTime, lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        scenarioHandler = GameObject.Find("ScenarioContainer").GetComponent<ScenarioHandler>();
        train = GameObject.Find("TrainControl").GetComponent<TrainMove>();
        light = GetComponent<Light>();

        lerpSpeed = PARAMETERS.LightActivationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        linearGain = (PARAMETERS.TunnelLength - (Mathf.Abs(train.activeTrainDistance) - PARAMETERS.PlatformLength / 2)) / PARAMETERS.TunnelLength;
        logGain = PARAMETERS.TunnelLength / Mathf.Abs(train.activeTrainDistance - PARAMETERS.PlatformLength / 2);

        if (isTriggered)
        {

            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * lerpSpeed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / (PARAMETERS.LightEnd - PARAMETERS.LightStart);

            Debug.Log("I HAVE BEEN TRIGGERED");
            // transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, turningRate * Time.deltaTime);
            // float fractionCompleted = (transform.eulerAngles.x - _targetRotation.eulerAngles.x) / transform.eulerAngles.x;
            light.range = Mathf.Lerp(PARAMETERS.LightStart, PARAMETERS.LightEnd, fracJourney);
        }

        //if (controlIntensity)
        //{
        //    light.intensity = Mathf.Clamp(logGain * PARAMETERS.pointLightDeceptionFactor, 0, 5);
        //}

        //else if (controlOrientation)
        //{
        //    if (PARAMETERS.directions[scenarioHandler.scenarioIndex] == 1)
        //    {
        //        light.gameObject.transform.rotation = Quaternion.Euler(PARAMETERS.spotLightStart - Mathf.Clamp(linearGain + PARAMETERS.spotLightDeceptionOffset, 0, 1) * (PARAMETERS.spotLightStart - PARAMETERS.spotLightEnd), 0, 0);
        //    }
        //    else if (PARAMETERS.directions[scenarioHandler.scenarioIndex] == -1)
        //    {
        //        Debug.Log("Linear Gain: " + linearGain + " Calc: " + Mathf.Clamp(linearGain + PARAMETERS.spotLightDeceptionOffset, 0, 1) * (PARAMETERS.spotLightStart - PARAMETERS.spotLightEnd));
        //        light.gameObject.transform.rotation = Quaternion.Euler(Mathf.Clamp(linearGain + PARAMETERS.spotLightDeceptionOffset, 0, 1) * (PARAMETERS.spotLightStart - PARAMETERS.spotLightEnd), 0, 0);
        //    }

        //    Debug.Log(transform.eulerAngles.x);

        //    light.intensity = Mathf.Clamp(logGain * PARAMETERS.pointLightDeceptionFactor, 0, 5);
    }

    public void TriggerLight()
    {
        isTriggered = true;
        startTime = Time.time;
    }
}
