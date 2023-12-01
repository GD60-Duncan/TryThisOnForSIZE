using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoseCondition : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverObj;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
       if(collider.CompareTag("Player"))
       {
            
            Time.timeScale = 0;

            GameData.GameOver = true;

            Instantiate(_gameOverObj);

            GameData.PlayerControl.GetComponent<Respawn>().ObjectRespawn(GameData.PlayerObj);

       }
    }
}
