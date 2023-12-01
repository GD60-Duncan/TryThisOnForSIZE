using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
//using Steamworks;

[CreateAssetMenu]

// [Flags]
// public enum PP
// {
//     None = 0,
//     ControlsAsigned = 1,

// }

public class SaveData : ScriptableObject
{
    public bool EditorDebugLines;
    
    [Header("GameState")]

    [Range(0,3)]
    public int CurrentLevelGroup;

    [Min(0)]
    public int Coins;

    public Vector3 SavePoint;

    public int CurrentHealth;

    //public MenuTypes CurrentMenu = MenuTypes.MainMenu;

    public bool BossDefeated;

    [Header("PlayerPrefernces")]

    public KeyCode Left;

    public KeyCode Right;

    public KeyCode Jump;

    public KeyCode Exit;

    public byte TestBool;

    public bool AutoLogin;

    public bool Help = true;

    public bool Info;

    public bool ExtraInfo;

    public bool PerformenceTracking;

    public byte FPSTrackingType;

    public bool Grain;

    public bool ChromaticAberration;

    public bool LensDistortion;

    public bool ColorGrading;

    public bool Bloom;

    public bool UIPostProcess;

    public bool FriendlyFire;

    public bool ControlsAsigned;

    public int antiAliasing;

    private string filePath;

    private string dataToStore;

    private string dataToLoad;

    public void Save()
    {
        filePath = Application.persistentDataPath;
        
        string fullPath = Path.Combine(filePath, this.name + ".txt");
        Debug.Log(fullPath);
        try
        {
            string json = JsonUtility.ToJson(this);
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            dataToStore = XorTest(json);
            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                    //writer.Close();
                }
            }
        
        }

        catch (Exception e)
        {
            Debug.LogError("Something went wrong saving the data to" + filePath + e);
        }
        //Debug.Log(json);
    }

    public void Load()
    {
        filePath = Application.persistentDataPath;
        string fullPath = Path.Combine(filePath, this.name + ".txt");

        if(File.Exists(fullPath))
        {
            try
            {
                using(FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                        dataToLoad = XorTest(dataToLoad);
                        JsonUtility.FromJsonOverwrite(dataToLoad, this);
                    
                    }
                }

        
            }

            catch (Exception e)
            {
                Debug.LogError("Something went wrong acessing the data" + e);
            }
        }

    }

    public void Reset()
    {

        Coins = 0;
        CurrentLevelGroup = 0;
        BossDefeated = false;


        Save();
    }

    private byte [] ivBytes = new byte [16];

    private void GenerateIVBytes()
    {
        System.Random rand = new System.Random();
        rand.NextBytes(ivBytes);
    }

    private string XorTest(string data)
    {
        string modifiedData = "";
        int l = data.Length;

        for(int i = 0; i < l; i++)
        {
            modifiedData += (char) (data[i] ^ filePath[i % filePath.Length]);
        }

        return modifiedData;
    }
    
}
