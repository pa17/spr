using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    ScenarioHandler scenarioHandler;

    public float countdownTime = PARAMETERS.countdownTime;
    private float timeLeft;

    public bool isActive;

    public Text startText; // used for showing countdown from 3, 2, 1 

    public string[] demoDescriptors;

    public bool loopForDemo = false;

    void Start()
    {
        timeLeft = countdownTime;
        scenarioHandler = GameObject.Find("ScenarioContainer").GetComponent<ScenarioHandler>();

        isActive = false;

        demoDescriptors = new string[5] { "Control Scenario (no intervention)", "Directional Audio", "Directional Audio + Light Illusion", "Block Obstruction", "Curtain Obstruction" };
    }

    void Update()
    {
        if (isActive)
        {
            timeLeft -= Time.deltaTime;

            if (scenarioHandler.scenarioIndex <= (PARAMETERS.numberOfScenarios - 1)) {
                startText.text = demoDescriptors[scenarioHandler.scenarioIndex] + System.Environment.NewLine + System.Environment.NewLine + " Scenario starts in... " + (timeLeft).ToString("0") + " seconds.";
                if (timeLeft < 0)
                {
                    scenarioHandler.SwitchScenario();
                    this.gameObject.SetActive(false);
                }
            }

            // Once all scenarios are run through... Take back to menu
            else
            {
                if (!loopForDemo)
                {
                    startText.text = "Submitting results..." + System.Environment.NewLine + System.Environment.NewLine + "You are taken back to the main menu.";
                    // Waiting for user input to submit.
                }
                else
                {
                    // Reset to loop...
                    scenarioHandler.scenarioIndex = 0;
                }
            }
        }
    }

    public void ResetCountdown()
    {
        timeLeft = countdownTime;
        this.gameObject.SetActive(true);
    }
}