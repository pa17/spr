using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S6_PlayerInterrupt : MonoBehaviour
{
    S6_ScenarioHandler scenarioHandler;
    S6_Countdown countdown;
    S6_SendToGoogle sendToGoogle;

    FreeNavigateHandler freeNavigateHandler;

    GameObject countdownTarget;
    GameObject welcomeTarget;
    GameObject freeNavigateTarget;

    // Start is called before the first frame update
    void Start()
    {
        countdownTarget = GameObject.Find("Countdown");
        welcomeTarget = GameObject.Find("Welcome");
        freeNavigateTarget = GameObject.Find("Free Navigate");


        scenarioHandler = GameObject.Find("S6_ScenarioContainer").GetComponent<S6_ScenarioHandler>();
        countdown = GetComponentInChildren<S6_Countdown>();
        freeNavigateHandler = GetComponentInChildren<FreeNavigateHandler>();
        sendToGoogle = GetComponentInChildren<S6_SendToGoogle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown.scenariosActive) {
            if (Input.GetMouseButtonDown(0))
            {

                // TODO: Log A
                Debug.Log("A");

            }

            else if(Input.GetMouseButtonDown(1))
            {
                // TODO: Log B
                Debug.Log("B");

            }
            else if (Input.GetMouseButtonDown(2))
            {
                scenarioHandler.timer.StopTimer();
                scenarioHandler.StopScenario();
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                scenarioHandler.trainHandler.ResetTrainPositions();
                countdown.ResetCountdown();
            }

            else if(Input.GetKeyDown(KeyCode.F12))
            {
                sendToGoogle.Send();
            }

            // Test over...
            if (scenarioHandler.scenarioIndex == 6)
            {
                countdownTarget.SetActive(false);
                welcomeTarget.SetActive(true);
            }
        }

        else if (freeNavigateHandler.freeNavigateActive)
        {
            // TODO: What happens with mouse clicks

            Debug.Log("TODO: What happens with mouse clicks");
        }
    }
}
