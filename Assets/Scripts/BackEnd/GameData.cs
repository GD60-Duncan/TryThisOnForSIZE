using System;
using UnityEngine;

[Flags]

public enum SaveFlags
{
    None = 0,
    Grain = 1,
    ChromaticAberration = 2,
    Bloom = 4,
    UIPostProcess = 8,
    FriendlyFire = 16,
    ControlsAsigned = 32, 
}



public static class GameData
{
    public static int CurrentSoundsPlaying;

    public static bool GamePaused; 

    public static bool CanInput;

    public static bool GameOver;

    public static bool InDoorway;

    public static GameObject PlayerObj;

    public static Movement playerMovement; 

    public static MovePlayer PlayerControl;

    public static SaveData savaData;

    public static CameraEffectManager CameraEffectManager;

    public static PickUpObjects PickUpObjects;

    public static ScaleObjects ScaleObjects;

    public static Camera ActiveCamera;



    }
