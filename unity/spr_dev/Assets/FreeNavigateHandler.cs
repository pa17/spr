using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeNavigateHandler : MonoBehaviour
{
    public bool freeNavigateActive;

    private float countdownTime = PARAMETERS.countdownTime;
    private float timeLeft;

    private Text navigateText;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = countdownTime;
        freeNavigateActive = false;

        Debug.Log("For some reasons it never goes into the free navigate update loop if right button pressed.")
    }

    // Update is called once per frame
    void Update()
    {
        if (freeNavigateActive)
        {
            timeLeft -= Time.deltaTime;

            navigateText.text = "Please roam around freely.";
            if (timeLeft < 0)
            {
                navigateText.text = " ";
            }
        }

        // Once done roaming around...
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
