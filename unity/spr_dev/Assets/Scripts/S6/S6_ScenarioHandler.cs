using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S6_ScenarioHandler : MonoBehaviour
{
    GameObject trainContainer;
    public S6_TrainHandler trainHandler;

    GameObject architecturalContainer;
    S6_ArchitecturalHandler architeturalHandler;

    GameObject player;
    Rigidbody playerRb;

    public Vector3 fixedPositionIllusion;
    public Vector3 fixedPositionObstruction;

    public S6_Timer timer;

    public int scenarioIndex;

    // Start is called before the first frame update
    void Start()
    {
        trainContainer = GameObject.Find("S6_TrainContainer");
        trainHandler = GetComponentInChildren<S6_TrainHandler>();

        architecturalContainer = GameObject.Find("S6_ArchitecturalContainer");
        architeturalHandler = GetComponentInChildren<S6_ArchitecturalHandler>();

        player = GameObject.Find("S6_Player");
        playerRb = player.GetComponent<Rigidbody>();

        scenarioIndex = 0;

        timer = GetComponent<S6_Timer>();

        // ON START

        architecturalContainer.SetActive(false);
        player.gameObject.transform.position = fixedPositionIllusion;
        playerRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;


    }

    public void StopScenario()
    {
        if (scenarioIndex < 4)
        {
            trainHandler.StopTrains();
            trainHandler.SwitchTrains();
            trainHandler.ResetTrainPositions();
        }
        else if (scenarioIndex == 4)
        {
            playerRb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
            player.gameObject.transform.position = fixedPositionObstruction;

            architecturalContainer.SetActive(true);
            trainHandler.StopTrains();
            trainHandler.ResetTrainPositions();
        }

        else
        {
            architecturalContainer.SetActive(true);
            trainHandler.StopTrains();
            trainHandler.ResetTrainPositions();

            // Move Player

            //architeturalHandler.SwitchIntervention();
        }
    }

    public void SwitchScenario()
    {
        //  Scenario 0: Control
        if (scenarioIndex == 0)
        {
            timer.ResetTimer();
            trainHandler.AccelerateTrains();

            scenarioIndex += 1;
        }
        // Scenario 1: Square
        else if (scenarioIndex == 1)
        {
            timer.ResetTimer();
            trainHandler.AccelerateTrains();

            scenarioIndex += 1;
        }
        // Scenario 2: Image
        else if (scenarioIndex == 2)
        {
            timer.ResetTimer();
            trainHandler.AccelerateTrains();

            scenarioIndex += 1;
        }
        // Scenario 3: Control
        else if (scenarioIndex == 3)
        {
            timer.ResetTimer();
            trainHandler.AccelerateTrains();

            scenarioIndex += 1;
        }
        // Scenario 4: Architectural 1
        else if (scenarioIndex == 4)
        {
            timer.ResetTimer();
            trainHandler.AccelerateTrains();

            scenarioIndex += 1;
        }
        // Scenario 5: Architectural 2
        else if (scenarioIndex == 5)
        {
            timer.ResetTimer();
            trainHandler.AccelerateTrains();

            scenarioIndex += 1;
        }
    }
}
