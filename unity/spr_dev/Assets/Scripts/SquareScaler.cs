using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SquareScaler : MonoBehaviour
{

    public Transform train;



    float start_distance = 200;

    public float SpeedSensitivity = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float z_pos = train.transform.position.z; // Starts at 200

        float gradient = 1 / ((1 / SpeedSensitivity) * start_distance);
        float intercept = 1 - start_distance * gradient;
        float new_scale = gradient * z_pos + intercept;


        // = (z_pos / start_distance) / SpeedSensitivity;

        transform.localScale = new Vector3(new_scale, new_scale, 1);


        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = new Vector3(10, 10, 0);
        }

    }

}
