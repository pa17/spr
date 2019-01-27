using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    public Camera CameraMain, CameraAlt;
    public bool camSwitch = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            camSwitch = !camSwitch;
            CameraMain.gameObject.SetActive(camSwitch);
            CameraAlt.gameObject.SetActive(!camSwitch);
        }
    }
}