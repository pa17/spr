using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S6_Countdown : MonoBehaviour
{
    S6_ScenarioHandler scenarioHandler;

    public float countdownTime = 10.0f;
    private float timeLeft;
    public Text startText; // used for showing countdown from 3, 2, 1 

    void Start()
    {
        timeLeft = countdownTime;
        scenarioHandler = GameObject.Find("S6_ScenarioContainer").GetComponent<S6_ScenarioHandler>();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        startText.text = "Hello! Scenario: " + scenarioHandler.scenarioIndex + ". The simulation will start in..." + System.Environment.NewLine + (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            scenarioHandler.SwitchScenario();
            this.gameObject.SetActive(false);
        }
    }

    public void ResetCountdown()
    {
        timeLeft = countdownTime;
        this.gameObject.SetActive(true);
    }
}