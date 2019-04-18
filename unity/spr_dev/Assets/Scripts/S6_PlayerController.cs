using UnityEngine;
using System.Collections;

public class S6_PlayerController : MonoBehaviour
{

    public float speed;
    public int mouseSensitivity = PARAMETERS.MouseSensitivity;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float forward = Input.GetAxis("Vertical");
        float side = Input.GetAxis("Horizontal");
        float rotY = Input.GetAxis("Mouse X");

        gameObject.transform.Rotate(0, rotY, 0);
        
        if (Input.GetKey(KeyCode.S)) {
            rb.velocity = new Vector3(0, 0, 0);
        }

        Vector3 speed = new Vector3(side, 0.0f, forward);

        rb.AddForce(gameObject.transform.rotation * speed);
    }
}