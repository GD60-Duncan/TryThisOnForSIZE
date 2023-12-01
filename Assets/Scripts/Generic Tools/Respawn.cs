using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public void ObjectRespawn(Vector3 SpawnTo, GameObject SpawnObject)
    {
        SpawnObject.transform.position = SpawnTo;
        // _deathParticle?.gameObject.SetActive(false);
        // _deathParticle?.gameObject.SetActive(true);
    }


    public void ObjectRespawn(GameObject SpawnObject)
    {
        SpawnObject.transform.position = this.gameObject.transform.position;
    }

    public void KillCharacter()
    {

    }

    

}
