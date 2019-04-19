using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{

    public float countdownTime = 10.0f;
    private float timeLeft;

    TrainAlteredHandler trainAlteredHandler;

    public Text startText; // used for showing countdown from 3, 2, 1 
    public UnityEngine.Events.UnityEvent startTrains;

    void Start()
    {
        timeLeft = countdownTime;
        trainAlteredHandler = GameObject.Find("TrainAlteredContainer").GetComponent<TrainAlteredHandler>();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        startText.text = "Hello! Scenario: " + trainAlteredHandler.alteredTrainIndex + ". The simulation will start in..." + System.Environment.NewLine + (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            startTrains.Invoke();
            this.gameObject.SetActive(false);
        }
    }

    public void ResetCountdown()
    {
        timeLeft = countdownTime;
        this.gameObject.SetActive(true);
    }
}