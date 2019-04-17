using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S6_Countdown : MonoBehaviour
{
    S6_ScenarioHandler scenarioHandler;

    public float countdownTime = PARAMETERS.countdownTime;
    private float timeLeft;

    public bool scenariosActive = false;

    public Text startText; // used for showing countdown from 3, 2, 1 

    void Start()
    {
        timeLeft = countdownTime;
        scenarioHandler = GameObject.Find("S6_ScenarioContainer").GetComponent<S6_ScenarioHandler>();
    }

    void Update()
    {
        if (scenariosActive)
        {
            timeLeft -= Time.deltaTime;

            if (scenarioHandler.scenarioIndex <= PARAMETERS.numberOfScenarios) {
                startText.text = "Scenario " + scenarioHandler.scenarioIndex + " will start in " + (timeLeft).ToString("0") + " seconds.";
                if (timeLeft < 0)
                {
                    scenarioHandler.SwitchScenario();
                    this.gameObject.SetActive(false);
                }
            }


            // Once all scenarios are run through... Take back to menu
            else
            {
                this.gameObject.SetActive(false);
            }

        }
    }

    public void ResetCountdown()
    {
        timeLeft = countdownTime;
        this.gameObject.SetActive(true);
    }
}