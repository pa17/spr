using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterrupt : MonoBehaviour
{   
    // NON UI
    ScenarioHandler scenarioHandler;
    ArchitecturalHandler architecturalHandler;
    SendToGoogle sendToGoogle;
    ResponseHandler response;
    PlayerController player;

    // UI Handlers
    WelcomeHandler welcome;
    Countdown countdown;
    FreeNavigateHandler freeNavigate;
    // UI GameObjects
    GameObject countdownTarget, welcomeTarget, freeNavigateTarget, navigateToFixedTarget;

    // Start is called before the first frame update
    void Start()
    {
        // NON UI
        scenarioHandler = GameObject.Find("ScenarioContainer").GetComponent<ScenarioHandler>();
        architecturalHandler = GameObject.Find("ArchitecturalContainer").GetComponent<ArchitecturalHandler>();
        sendToGoogle = GetComponentInChildren<SendToGoogle>();
        response = GetComponentInChildren<ResponseHandler>();
        player = GetComponent<PlayerController>();

        // UI Handlers
        welcome = GetComponentInChildren<WelcomeHandler>();
        countdown = GetComponentInChildren<Countdown>();
        freeNavigate = GetComponentInChildren<FreeNavigateHandler>();
        // UI GameObjects
        welcomeTarget = GameObject.Find("Welcome");
        countdownTarget = GameObject.Find("Countdown");
        freeNavigateTarget = GameObject.Find("Free Navigate");
        navigateToFixedTarget = GameObject.Find("Navigate To Fixed");


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
                if (scenarioHandler.scenarioIndex < PARAMETERS.numberOfScenarios)
                {
                    response.directionResponses[scenarioHandler.scenarioIndex] = 1;
                }
            }

            else if(Input.GetMouseButtonDown(1))
            {
                // Player perceived train from RIGHT
                Debug.Log("B");
                if (scenarioHandler.scenarioIndex < PARAMETERS.numberOfScenarios)
                {
                    response.directionResponses[scenarioHandler.scenarioIndex] = -1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (scenarioHandler.scenarioIndex < PARAMETERS.numberOfScenarios)
                {
                    scenarioHandler.timer.StopTimer();
                    scenarioHandler.StopScenario();
                }
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
            // Choose location in scenario 4...
            else if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                player.FreezePlayer();
                scenarioHandler.locationChosen = true;
                response.WriteChosenPosition(player.transform.position.z);
                navigateToFixedTarget.SetActive(false);
            }
        }

        // NAVIGATE
        else if (freeNavigate.isActive)
        {
            // TODO: What happens with mouse clicks

            if (Input.GetMouseButtonUp(0))
            {
                // TODO: Implement interaction
                architecturalHandler.gameObject.SetActive(true);
                architecturalHandler.SwitchIntervention();
            }

            else if (Input.GetMouseButtonUp(1))
            {
                architecturalHandler.gameObject.SetActive(false);

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
