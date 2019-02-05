using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SquareScaler : MonoBehaviour
{

    public Transform train;

    float z_pos = 100f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        z_pos = train.transform.position.z; // Starts at 200
        print(z_pos / 200f);

        transform.localScale = new Vector3(z_pos / 200f, z_pos / 200f, 1);

        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = new Vector3(10, 10, 0);
        }

        else if (Input.GetKey(KeyCode.E))
        {
        }
    }
}
