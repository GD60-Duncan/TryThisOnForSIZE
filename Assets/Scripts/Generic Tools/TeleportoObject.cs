using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportoObject : MonoBehaviour
{
    [SerializeField] private GameObject _telportLocation;

    [SerializeField] private bool _onEnable;

    [Header("Seconds before object is teleported")]
    [SerializeField] private float _delay;
    
    void OnEnable()
    {
        if(_onEnable == true)
        {
            Telport();
        }

        Invoke("Telport",_delay);
    }

    public void Telport()
    {
        transform.position = _telportLocation.transform.position;
    }
}
