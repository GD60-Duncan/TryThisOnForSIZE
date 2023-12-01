using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitRoom : LoadScene
{
    [SerializeField] private SaveData _saveData;
    [SerializeField] private Respawn _respawn;
    [SerializeField] private GameObject _gameObject;
    
    void Update()
    {
        if(Input.GetKeyDown(_saveData.Exit) && GameData.InDoorway && _gameObject.transform.localScale.x <= 1 &&  _gameObject.transform.localScale.y <= 1)
        {
            Exit();
        }
    }

    private void Exit()
    {
        Load(SceneManager.GetActiveScene().buildIndex + 1) ;
        _respawn.ObjectRespawn(_gameObject);
        
    }
}
