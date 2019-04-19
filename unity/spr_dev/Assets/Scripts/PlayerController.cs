using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public int mouseSensitivity = PARAMETERS.MouseSensitivity;

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
        float forward = Input.GetAxis("Vertical");
        float side = Input.GetAxis("Horizontal");
        float rotY = Input.GetAxis("Mouse X");

        gameObject.transform.Rotate(0, rotY * mouseSensitivity, 0);

        if (!isFrozen)
        {
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector3(0, 0, 0);
            }

            Vector3 speed = new Vector3(side, 0.0f, forward);

            rb.AddForce(gameObject.transform.rotation * speed);
        }
    }

    public void FreezePlayer()
    {
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