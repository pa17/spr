using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchitecturalHandler : MonoBehaviour
{
    GameObject[] interventions;
    public int interventionIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Get list of child GameObjects (scenarios)
        interventions = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            interventions[i] = transform.GetChild(i).gameObject;

            // Turn off all scenarios
            interventions[i].SetActive(false);
        }
    }

    public void SwitchIntervention()
    {
        if (interventionIndex < 4)
        {
            interventionIndex += 1;
        }
        else
        {
            interventionIndex = 0;
        }

        for (int i = 0; i < 4; i++)
        {
            if (i == interventionIndex)
            {
                interventions[i].SetActive(true);
            }
            else
            {
                interventions[i].SetActive(false);
            }
        }
    }
}
