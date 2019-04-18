using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionProbeController : MonoBehaviour
{

    GameObject player;
    ReflectionProbe reflectionProbe;

    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        reflectionProbe = GetComponent<ReflectionProbe>();
        player = GameObject.Find("S6_Player");

        startPosition = reflectionProbe.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        reflectionProbe.transform.position = new Vector3(player.transform.position.x, startPosition.y, startPosition.z);
    }
}
