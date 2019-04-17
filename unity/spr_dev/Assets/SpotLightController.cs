using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{
    S6_TrainHandler trainHandler;
    Light spotlight;

    // Start is called before the first frame update
    void Start()
    {
        trainHandler = GameObject.Find("S6_TrainContainer").GetComponent<S6_TrainHandler>();
        spotlight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        spotlight.intensity = Mathf.Clamp(PARAMETERS.TunnelLength /Mathf.Abs(trainHandler.activeTrainDistance - PARAMETERS.PlatformLength / 2) * PARAMETERS.spotlightDeceptionFactor, 0, 5);
    }
}
