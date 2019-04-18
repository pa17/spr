using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeNavigateHandler : MonoBehaviour
{
    public bool isActive = false;

    private float countdownTime = 5;
    private float timeLeft;

    public Text navigateText;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = countdownTime;

        Debug.Log("For some reasons it never goes into the free navigate update loop if right button pressed.");
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timeLeft -= Time.deltaTime;

            navigateText.text = "Please explore the station freely." + System.Environment.NewLine + System.Environment.NewLine + "- Left click to interact" + System.Environment.NewLine + "- Middle click to change intervention" + System.Environment.NewLine + "- Right click to exit";
            if (timeLeft < 0)
            {
                navigateText.text = " ";
            }
        }

        // Once done roaming around...
        else
        {
            timeLeft = countdownTime;
        }
    }
}
