using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool mouseEnabled;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.XR.InputTracking.disablePositionalTracking = true;
    }

    void FixedUpdate()
    {
        float rotY = Input.GetAxis("Mouse X");

        if (mouseEnabled)
        {
            gameObject.transform.Rotate(0, rotY * PARAMETERS.MouseSensitivity, 0);
        }
    }
}
