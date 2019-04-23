using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    LightController scenarioThreeLight;
    ScenarioHandler scenarioHandler;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(7, 3, PARAMETERS.PlatformLength + 2 * PARAMETERS.TriggerDistance);

        scenarioHandler = GameObject.Find("ScenarioContainer").GetComponent<ScenarioHandler>();

        scenarioThreeLight = GameObject.Find("Scenario 3 - Audio + Light").GetComponentInChildren<LightController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Train")
        {
            Debug.Log("Train ARRIVES!" + other);
            if (scenarioHandler.scenarioIndex == 2)
            {
                scenarioThreeLight.TriggerLight();
            }
        }
    }
}
