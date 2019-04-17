using System;

public static class PARAMETERS
{
    public static float PlatformLength = 121.5f;
    public static float TrainStartDistance = 300f;
    public static float TrainDistanceToEntry = TrainStartDistance - PlatformLength;
    public static float TunnelLength = TrainStartDistance - PlatformLength / 2;


    // Test scenario
    public static float countdownTime = 3; // Time from scenario announcement to start

    public static int numberOfScenarios = 6;

    // Deception
    public static float spotlightDeceptionFactor = 2; // Factor by which wrong side gets lighter faster

    public static float loudspeakerDeceptionGain = 2; // Factpr by which wrong side gets louder faster
}
