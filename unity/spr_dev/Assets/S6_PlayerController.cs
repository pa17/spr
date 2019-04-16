using UnityEngine;
using System.Collections;

public class S6_PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    private S6_TrainHandler trainHandler;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        trainHandler = GameObject.Find("S6_TrainContainer").GetComponent<S6_TrainHandler>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);


        // Make player follow train
        // transform.position = new Vector3(0.4f, 1f, trainHandler.activeTrainDistance - 20);

    }
}