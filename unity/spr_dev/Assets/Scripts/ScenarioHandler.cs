using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioHandler : MonoBehaviour
{
    public TrainMove train;
    public Timer timer;
    NavigateToFixedHandler navigateToFixedHandler;
    GameObject navigateToFixedTarget;
    AudioSource trainAudio;
    AudioRenderer audioRenderer;
    PlayerController player;

    public int scenarioIndex = 0;
    public bool locationChosen = false;

    GameObject[] scenarios;

    // Start is called before the first frame update
    void Start()
    {
        train = GameObject.Find("TrainControl").GetComponent<TrainMove>();
        trainAudio = GameObject.Find("TrainControl").GetComponent<AudioSource>();
        navigateToFixedHandler = GameObject.Find("Navigate To Fixed").GetComponent<NavigateToFixedHandler>();
        navigateToFixedTarget = GameObject.Find("Navigate To Fixed");
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        audioRenderer = GameObject.Find("MainCamera").GetComponent<AudioRenderer>();

        timer = GetComponent<Timer>();

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
            trainAudio.Stop();
            train.ResetTrainPosition(PARAMETERS.directions[scenarioIndex]);

            //audioRenderer.Save("test.wav");

            // Turn off scenario just passed
            scenarios[scenarioIndex].SetActive(false);

            scenarioIndex += 1;
        }

        // Player choose location
        if (scenarioIndex == 3)
        {
            navigateToFixedTarget.SetActive(true);
            navigateToFixedHandler.SetText();
            // Disable lights for scenario 4 - 6
            train.DisableLights();
            player.UnfreezePlayer();
        }
    }

    public void SwitchScenario()
    // WHAT HAPPENS WHEN THE SCENARIO STARTS
    {
        if (scenarioIndex <= PARAMETERS.numberOfScenarios)
        {
            scenarios[scenarioIndex].SetActive(true);

            if (scenarioIndex == 1 | scenarioIndex == 2)
            {
                ArtificialLoudspeakerHandler scenarioAudio = scenarios[scenarioIndex].GetComponentInChildren<ArtificialLoudspeakerHandler>();
                scenarioAudio.Play();
            }

            trainAudio.Play();
            SwitchScenarioDirection();
            train.SwitchDirection(PARAMETERS.directions[scenarioIndex]);
            train.Accelerate(PARAMETERS.directions[scenarioIndex]);
            timer.ResetTimer();
            Debug.Log("Timer RESET: " + scenarioIndex);
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
