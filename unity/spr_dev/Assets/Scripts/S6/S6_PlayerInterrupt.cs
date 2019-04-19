using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S6_PlayerInterrupt : MonoBehaviour
{   
    // NON UI
    S8_ScenarioHandler scenarioHandler;
    S6_SendToGoogle sendToGoogle;
    S6_ResponseHandler response;
    S6_PlayerController player;

    // UI Handlers
    WelcomeHandler welcome;
    S6_Countdown countdown;
    FreeNavigateHandler freeNavigate;
    // UI GameObjects
    GameObject countdownTarget;
    GameObject welcomeTarget;
    GameObject freeNavigateTarget;

    // Start is called before the first frame update
    void Start()
    {
        // NON UI
        scenarioHandler = GameObject.Find("S8_ScenarioContainer").GetComponent<S8_ScenarioHandler>();
        sendToGoogle = GetComponentInChildren<S6_SendToGoogle>();
        response = GetComponentInChildren<S6_ResponseHandler>();
        player = GetComponent<S6_PlayerController>();

        // UI Handlers
        welcome = GetComponentInChildren<WelcomeHandler>();
        countdown = GetComponentInChildren<S6_Countdown>();
        freeNavigate = GetComponentInChildren<FreeNavigateHandler>();
        // UI GameObjects
        welcomeTarget = GameObject.Find("Welcome");
        countdownTarget = GameObject.Find("Countdown");
        freeNavigateTarget = GameObject.Find("Free Navigate");

        // Freeze player
        player.FreezePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (welcome.isActive)
        {
            if (Input.GetMouseButtonUp(0))
            {
                countdown.isActive = true;

                welcome.isActive = false;
                welcomeTarget.SetActive(false);
            }

            else if (Input.GetMouseButtonUp(1))
            {
                freeNavigate.isActive = true;

                welcome.isActive = false;
                welcomeTarget.SetActive(false);

                player.UnfreezePlayer();
            }
        }

        // SCENARIOS
        else if (countdown.isActive) {
            if (Input.GetMouseButtonDown(0))
            {
                // Player perceived train from LEFT
                Debug.Log("A");
                response.directionResponses[scenarioHandler.scenarioIndex] = 1;
            }

            else if(Input.GetMouseButtonDown(1))
            {
                // Player perceived train from RIGHT
                Debug.Log("B");

                response.directionResponses[scenarioHandler.scenarioIndex] = -1;
            }
            else if (Input.GetMouseButtonDown(2))
            {
                scenarioHandler.timer.StopTimer();
                scenarioHandler.StopScenario();
            }

            else if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                countdown.ResetCountdown();
            }

            else if(Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                sendToGoogle.Send();

                countdown.isActive = false;
                countdownTarget.SetActive(false);

                welcomeTarget.SetActive(true);
                welcome.isActive = true;

                player.UnfreezePlayer();
            }
        }

        // NAVIGATE
        else if (freeNavigate.isActive)
        {
            // TODO: What happens with mouse clicks

            if (Input.GetMouseButtonUp(0))
            {
                // TODO: Implement interaction
                Debug.Log("TODO: Implement interaction");
            }

            else if (Input.GetMouseButtonUp(1))
            {
                freeNavigate.isActive = false;
                freeNavigateTarget.SetActive(false);

                welcome.isActive = true;
                welcomeTarget.SetActive(true);

                player.ResetPlayer();
                player.FreezePlayer();
            }
        }
    }
}
