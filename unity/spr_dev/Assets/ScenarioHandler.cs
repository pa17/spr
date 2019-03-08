using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioHandler : MonoBehaviour
{

    TrainHandler trainHandler;
    ArchitecturalHandler architeturalHandler;

    // Start is called before the first frame update
    void Start()
    {
        trainHandler = GetComponentInChildren<TrainHandler>();
        architeturalHandler = GetComponentInChildren<ArchitecturalHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
