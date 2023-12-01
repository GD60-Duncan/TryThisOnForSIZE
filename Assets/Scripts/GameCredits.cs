using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCredits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameData.PlayerControl.gameObject);
        Destroy(AudioManager.instance.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
