using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S8_ScenarioHandler : MonoBehaviour
{
    public S6_TrainMove train;
    public S6_Timer timer;

    public int scenarioIndex = 0;

    GameObject[] scenarios;

    // Start is called before the first frame update
    void Start()
    {
        train = GameObject.Find("TrainControl").GetComponent<S6_TrainMove>();
        timer = GetComponent<S6_Timer>();

        // Get list of child GameObjects (scenarios)
        scenarios = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            scenarios[i] = transform.GetChild(i).gameObject;

            // Turn off all scenarios
            scenarios[i].SetActive(false);
        }
    }

    public void StopScenario()
    // WHAT HAPPENS WHEN THE PLAYER INTERRUPTS
    {
        if (scenarioIndex <= PARAMETERS.numberOfScenarios)
        {
            train.StopTrain();
            train.ResetTrainPosition(PARAMETERS.directions[scenarioIndex]);

            // Turn off scenario just passed
            scenarios[scenarioIndex].SetActive(false);

            scenarioIndex += 1;
        }
    }

    public void SwitchScenario()
    // WHAT HAPPENS WHEN THE SCENARIO STARTS
    {
        //  Scenario 1: Control
        if (scenarioIndex <= PARAMETERS.numberOfScenarios)
        {
            scenarios[scenarioIndex].SetActive(true);
            SwitchScenarioDirection();

            train.SwitchDirection(PARAMETERS.directions[scenarioIndex]);
            train.Accelerate(PARAMETERS.directions[scenarioIndex]);

            timer.ResetTimer();
        }

        else
        {
            // Increment once to break condition in countdown. Then wait on user input to submit results.
            scenarioIndex += 1;
        }
    }

    public void SwitchScenarioDirection()
    {
        scenarios[scenarioIndex].transform.localScale = new Vector3 (1, 1, PARAMETERS.directions[scenarioIndex]);
    }
}
