using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterrupt : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent stopTrains;
    public UnityEngine.Events.UnityEvent switchSimulation;
    public UnityEngine.Events.UnityEvent resetTrainPositions;

    CameraSwitcher cameraSwitcher;
    TrainHandler trainHandler;
    TrainAlteredHandler trainAlteredHandler;

    // Start is called before the first frame update
    void Start()
    {
        trainHandler = GameObject.Find("TrainContainer").GetComponent<TrainHandler>();
        trainAlteredHandler = GameObject.Find("TrainAlteredContainer").GetComponent<TrainAlteredHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            stopTrains.Invoke();
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            resetTrainPositions.Invoke();
            switchSimulation.Invoke();
        }
    }
}
