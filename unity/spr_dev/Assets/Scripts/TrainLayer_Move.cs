using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainLayer_Move : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        //audioSource = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddRelativeForce(Vector3.back);

            //if (!audioSource.isPlaying)
            //{
            //    audioSource.Play();
            //}
        }

        else if (Input.GetKey(KeyCode.S))
        {
            rigidBody.AddRelativeForce(Vector3.forward);
        }

        else if (Input.GetKey(KeyCode.C))
        {
            rigidBody.velocity = new Vector3(0, 0, -10);
        }

        else if (Input.GetKey(KeyCode.V))
        {
            rigidBody.velocity = new Vector3(0, 0, -20);
        }

        else if (Input.GetKey(KeyCode.B))
        {
            rigidBody.velocity = new Vector3(0, 0, -35);
        }

        else if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.velocity = new Vector3(0, 0, 0);
            print("Distance from main camera: " + (rigidBody.position.z - 50));
        }


        // Scenario 1
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            rigidBody.position = new Vector3(-2.2f, 4, 200);
            rigidBody.velocity = new Vector3(0, 0, -10);
            print("Distance from main camera: " + (rigidBody.position.z - 50));
        }


        // Scenario 2
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            rigidBody.position = new Vector3(-2.2f, 4, 200);
            rigidBody.velocity = new Vector3(0, 0, -20);
            print("Distance from main camera: " + (rigidBody.position.z - 50));
        }


        // Scenario 3
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            rigidBody.position = new Vector3(-2.2f, 4, 200);
            rigidBody.velocity = new Vector3(0, 0, -35);
            print("Distance from main camera: " + (rigidBody.position.z - 50));
        }
    }
}
