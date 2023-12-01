using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameData.PlayerControl.gameObject.transform.position = this.gameObject.transform.position;
    }

    
}
