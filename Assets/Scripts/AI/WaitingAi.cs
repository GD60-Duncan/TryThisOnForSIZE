using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingAi : AIBase
{
    [SerializeField] private int  _startDirection;
    
    protected override void Awake()
    {
        base.Awake();

        Setdirection = _startDirection;
    }
    
    protected override void AiBehavoir()
    {
        if(CanSee)
        {
            TrackTarget();
        }

        if(State == AIStates.Idle)
        {
            Stop();
        }
    }
}
