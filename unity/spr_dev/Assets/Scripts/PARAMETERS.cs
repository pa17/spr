using System;

public static class PARAMETERS
{
    // Platform & Train Distances
    public static float PlatformLength = 121.5f;
    public static float TrainStartDistance = 500f;
    public static float TunnelLength = TrainStartDistance - PlatformLength / 2;

    // Train
    public static float TrainSpeed = -20f;

    // Test scenario
    public static float countdownTime = 3; // Time from scenario announcement to start
    public static int numberOfScenarios = 6;
    public static int[] directions = { 1, -1, 1, 1, 1, 1 };     // Direction: Left is 1, Right is -1.
    // S1: 1, S2: -1, S3: 1, S4: 1, S5: 1, S6: 1

    // Player
    public static int MouseSensitivity = 4;

    // Audio Illusion
    public static float TrainVolume = 0.4f; // Volume at distance = 0
    public static float LoudspeakerVolumeIncrease = 0.8f; // Volume at distance = 0;
    public static float LoudspeakerBaseVolume = 0.2f; // Factor by which wrong side gets louder faster

    // Light Illusion
    public static int TriggerDistance = 150; // Distance from end of tunnel when light illusion is triggered
    public static int LightStart = 30;
    public static int LightEnd = 140;
    public static float LightActivationTime = 10; 
    public static float LightActivationSpeed = (LightEnd - LightStart) / LightActivationTime; // Light moves with x metres per second
}
