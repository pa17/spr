﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private bool isFrozen = true;

    public Rigidbody rb;

    private Vector3 initialPosition;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        float forward = Input.GetAxis("Horizontal");

        if (!isFrozen)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.drag = 10;
            }
            else
            {
                rb.drag = 0.2f;
            }

            Vector3 speed = new Vector3(forward, 0.0f, 0.0f);

            rb.AddForce(gameObject.transform.rotation * speed);
        }
    }

    public void FreezePlayer()
    {
        rb.velocity = new Vector3(0, 0, 0);
        isFrozen = true;
    }

    public void UnfreezePlayer()
    {
        isFrozen = false;
    }

    public void ResetPlayer()
    {
        transform.position = new Vector3(-2.13f, 1, 0);
        transform.rotation = Quaternion.Euler(0, 90, 0);
        rb.velocity = new Vector3(0, 0, 0);
    }
}