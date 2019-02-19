using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainAlteredSwitcher : MonoBehaviour
{

    public GameObject[] alteredTrains;
    public int counter;

    // Start is called before the first frame update
    void Start()
    {
        alteredTrains = GameObject.FindGameObjectsWithTag("AlteredTrain");
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            counter += 1;
            SwitchAlteredTrains();
        }


        void SwitchAlteredTrains()
        {
            int loop_counter = 0;
            foreach (GameObject train in alteredTrains)
            {
                if (counter == loop_counter)
                {
                    train.SetActive(true);
                }

                else
                {
                    train.SetActive(false);
                }
                loop_counter += 1;
            }

            if (counter == alteredTrains.Length)
            {
                counter = 0;
            }
        }
    }
}
