using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SquareScaler : MonoBehaviour
{
    public Transform train;
    public float relDistance = 230;
    public float speedSensitivity = 1;

    // Update is called once per frame
    void Update()
    {
        float zPosRel = train.transform.position.z - relDistance;

        float gradient = 1 / ((1 / speedSensitivity) * relDistance);
        float intercept = 1 - relDistance * gradient;
        float new_scale = gradient * zPosRel + intercept;


        // = (z_pos / start_distance) / SpeedSensitivity;

        transform.localScale = new Vector3(new_scale, new_scale, 1);
    }
}
