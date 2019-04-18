using System;

public static class PARAMETERS
{
    // Platform & Train Distances
    public static float PlatformLength = 121.5f;
    public static float TrainStartDistance = 300f;

    public static float TrainDistanceToEntry = TrainStartDistance - PlatformLength;
    public static float TunnelLength = TrainStartDistance - PlatformLength / 2;

    // Train
    public static float TrainSpeed = -20f;

    public static float HideTrainDistance = 50;


    // Test scenario
    public static float countdownTime = 3; // Time from scenario announcement to start
    public static int numberOfScenarios = 6;
    public static int[] directions = { 1, -1, -1, -1, 1, 1 };     // Direction: Left is 1, Right is -1.


    // Player
    public static int MouseSensitivity = 4;

    // Deception
    public static float spotlightDeceptionFactor = 2; // Factor by which wrong side gets lighter faster

    public static float loudspeakerDeceptionGain = 2; // Factpr by which wrong side gets louder faster
}
