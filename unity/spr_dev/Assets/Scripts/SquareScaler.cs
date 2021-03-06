﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SquareScaler : MonoBehaviour
{
    public Transform train;

    public float speedSensitivity = 1;

    private float startDistance;

    // Update is called once per frame
    private void Start()
    {
        startDistance = train.transform.position.z;
    }

    void Update()
    {
        float zPosRel = train.transform.position.z;

        float gradient = 1 / ((1 / speedSensitivity) * startDistance);
        float intercept = 1 - startDistance * gradient;
        float new_scale = gradient * zPosRel + intercept;


        // = (z_pos / start_distance) / SpeedSensitivity;

        transform.localScale = new Vector3(new_scale, new_scale, 1);
    }
}
