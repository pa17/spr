using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterrupt : MonoBehaviour
{
    // Events
    public UnityEngine.Events.UnityEvent stopTrains;
    public UnityEngine.Events.UnityEvent switchSimulation;
    public UnityEngine.Events.UnityEvent resetTrainPositions;

    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer.StopTimer();
            stopTrains.Invoke();
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            resetTrainPositions.Invoke();
            switchSimulation.Invoke();
        }
    }
}
