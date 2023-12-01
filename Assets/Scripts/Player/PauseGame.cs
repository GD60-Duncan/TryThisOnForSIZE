using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    private GameObject uiInstance;

    private int boolvalue;
    
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameData.GameOver) return;
            
            Pause(GameData.GamePaused);
        }
    }

    private void Pause(bool ispaused)
    {
        if(uiInstance == null)
        {
            uiInstance = Instantiate(_pauseMenu);
        }
        
        boolvalue = ispaused ? 1 : 0;

        Time.timeScale = boolvalue;

        boolvalue = Mathf.Abs(boolvalue -1);

        GameData.GamePaused = Convert.ToBoolean(boolvalue);

        uiInstance.SetActive(GameData.GamePaused);

        

    }
}
