using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    public Camera Camera_1, Camera_2, Camera_3;
    public char activeCam = '1';

    void Start()
    {
        {
            Camera_1.gameObject.SetActive(false);
            Camera_2.gameObject.SetActive(false);
            Camera_3.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Camera_1.gameObject.SetActive(true);
            Camera_2.gameObject.SetActive(false);
            Camera_3.gameObject.SetActive(false);
            activeCam = '1';
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Camera_1.gameObject.SetActive(false);
            Camera_2.gameObject.SetActive(true);
            Camera_3.gameObject.SetActive(false);
            activeCam = '2';
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Camera_1.gameObject.SetActive(false);
            Camera_2.gameObject.SetActive(false);
            Camera_3.gameObject.SetActive(true);
            activeCam = '3';
        }
    }
}