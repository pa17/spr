using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{
    S6_TrainMove train;
    Light spotlight;

    // Start is called before the first frame update
    void Start()
    {
        train = GameObject.Find("TrainControl").GetComponent<S6_TrainMove>();
        spotlight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        spotlight.intensity = Mathf.Clamp(PARAMETERS.TunnelLength /Mathf.Abs(train.activeTrainDistance - PARAMETERS.PlatformLength / 2) * PARAMETERS.spotlightDeceptionFactor, 0, 5);
    }
}
