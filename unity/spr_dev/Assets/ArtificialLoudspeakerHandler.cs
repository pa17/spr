using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialLoudspeakerHandler : MonoBehaviour
{

    AudioSource audioSource;
    ONSPAudioSource oculusSpatialiser;
    TrainMove train;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // oculusSpatialiser = GetComponent<ONSPAudioSource>();
        train = GameObject.Find("TrainControl").GetComponent<TrainMove>();
    }

    private void Update()
    {
        // oculusSpatialiser.Gain = ((PARAMETERS.TrainStartDistance - Mathf.Abs(train.activeTrainDistance)) / PARAMETERS.TrainStartDistance) * PARAMETERS.LoudspeakerDeceptionGain;
        audioSource.volume = PARAMETERS.LoudspeakerVolumeIncrease * (((PARAMETERS.TrainStartDistance - Mathf.Abs(train.activeTrainDistance)) / PARAMETERS.TrainStartDistance)) + PARAMETERS.LoudspeakerBaseVolume;
    }

    public void Play()
    {
        audioSource.Play();
    }
}
