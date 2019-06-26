using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoController : MonoBehaviour
{
    // NON UI
    ScenarioHandler scenarioHandler;
    ArchitecturalHandler architecturalHandler;
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
        Debug.Log(scenarioHandler.timer.timePassed - scenarioHandler.timer.timer);
        if ((scenarioHandler.timer.timePassed - scenarioHandler.timer.timer) >= 25 && scenarioHandler.timer.timerReset == false)
        {
            // Stop scenario (WHEN TIMER exceeds x seconds)
            scenarioHandler.timer.StopTimer();
            scenarioHandler.StopScenario();
            // Next scenario (Automatically)
            countdown.ResetCountdown();
        }
    }
}
