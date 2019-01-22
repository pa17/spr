﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove_Tube : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            rigidBody.AddRelativeForce(Vector3.right);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        else if (Input.GetKey(KeyCode.S))
        {
            rigidBody.AddRelativeForce(Vector3.left);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddRelativeForce(Vector3.forward);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddRelativeForce(Vector3.back);
        }
    }
}
