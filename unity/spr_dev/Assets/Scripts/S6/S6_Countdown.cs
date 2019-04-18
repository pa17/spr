using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S6_Countdown : MonoBehaviour
{
    S8_ScenarioHandler scenarioHandler;

    public float countdownTime = PARAMETERS.countdownTime;
    private float timeLeft;

    public bool isActive;

    public Text startText; // used for showing countdown from 3, 2, 1 

    void Start()
    {
        timeLeft = countdownTime;
        scenarioHandler = GameObject.Find("S8_ScenarioContainer").GetComponent<S8_ScenarioHandler>();

        isActive = false;
    }

    void Update()
    {
        if (isActive)
        {
            timeLeft -= Time.deltaTime;

            if (scenarioHandler.scenarioIndex <= (PARAMETERS.numberOfScenarios - 1)) {
                startText.text = "Scenario " + (scenarioHandler.scenarioIndex + 1) + " will start in... " + System.Environment.NewLine + System.Environment.NewLine + (timeLeft).ToString("0") + " seconds.";
                if (timeLeft < 0)
                {
                    scenarioHandler.SwitchScenario();
                    this.gameObject.SetActive(false);
                }
            }

            // Once all scenarios are run through... Take back to menu
            else
            {
                startText.text = "Submitting results..." + System.Environment.NewLine + System.Environment.NewLine + "You are taken back to the main menu.";
                // Waiting for user input to submit.
            }

        }
    }

    public void ResetCountdown()
    {
        timeLeft = countdownTime;
        this.gameObject.SetActive(true);
    }
}