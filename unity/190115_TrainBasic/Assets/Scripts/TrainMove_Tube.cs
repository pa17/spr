using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove_Tube : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;
    MeshRenderer meshRenderer;

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
            print(rigidBody.position.z - 50);
        }
    }
}
