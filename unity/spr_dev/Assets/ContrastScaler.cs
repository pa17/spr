using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrastScaler : MonoBehaviour
{

    public Transform train;

    public float speedSensitivity = 1;

    private float startDistance;

    SpriteRenderer spriteRenderer;
    SpriteRenderer wallsRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        startDistance = train.transform.position.z;

        wallsRenderer = GameObject.Find("S6_WallFront").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float zPosRel = train.transform.position.z;

        float gradient = 1 / ((1 / speedSensitivity) * startDistance);
        float intercept = 1 - startDistance * gradient;
        float new_scale = gradient * zPosRel + intercept;


        // = (z_pos / start_distance) / SpeedSensitivity;
        spriteRenderer.color = new Color(new_scale, new_scale, new_scale, 1);

        wallsRenderer.color = new Color(1-new_scale, 1-new_scale, 1-new_scale, 1);

    }
}
