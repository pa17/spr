using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S6_PlayerInterrupt : MonoBehaviour
{
    S6_ScenarioHandler scenarioHandler;
    S6_Countdown countdown;
    S6_SendToGoogle sendToGoogle;

    // Start is called before the first frame update
    void Start()
    {
        scenarioHandler = GameObject.Find("S6_ScenarioContainer").GetComponent<S6_ScenarioHandler>();
        countdown = GetComponentInChildren<S6_Countdown>();
        sendToGoogle = GetComponentInChildren<S6_SendToGoogle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
    }
}
