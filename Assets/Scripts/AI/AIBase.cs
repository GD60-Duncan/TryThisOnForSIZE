using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AIBase : Movement
{
     [Header("Ai")]
    
    [SerializeField] protected GameObject _target;
     [SerializeField] protected Movement _targetMovement;

     [SerializeField] private float _reactionTime;

    
    protected Transform ctransform;

     protected int Setdirection = 1;

     public bool CanSee;

     public AIStates State;

     protected float timer;
    
    protected virtual void Awake()
    {
        ctransform = this.transform;

        //BasicBehavior();

        //Wait(0.5f, "AssignTarget");

        AssignTarget();

        StartCoroutine(SetUpAiLoop());

        
    }

    private IEnumerator SetUpAiLoop()
    {
        while(State == AIStates.Idle)
        {
            yield return null;
        }

        if(State != AIStates.Chasing)
        {
            yield return new WaitForSeconds(_reactionTime);
        }

        if(CanSee == true)
        {
            StartChase();
        }

        if(State == AIStates.Confused)
        {
            Stop();
            yield return new WaitForSeconds(1);
            Setdirection = (int)MathExtenions.InvertABS(Setdirection);
            yield return new WaitForSeconds(1);
            TrackTarget();
            State = AIStates.Idle;

            StartCoroutine(SetUpAiLoop());
            yield break;
        }

        while(State == AIStates.Chasing)
        {
            yield return null;
        }

        StartCoroutine(SetUpAiLoop());
    }

    protected void TrackTarget()
    {
        if(ctransform?.position.x > _target.transform.position.x)
                {
                    Setdirection = -1;
                }

                if(ctransform?.position.x < _target.transform.position.x)
                {
                    Setdirection = 1;
                }
    }

    private void AssignTarget()
    {
        _target = GameData.PlayerObj;
        _targetMovement = GameData.playerMovement;
    }

    void LateUpdate()
    {
        Move(CanMove, Setdirection);
        AiBehavoir();
    }

    protected virtual void AiBehavoir()
    {
        if(CanSee)
        {
            TrackTarget();
        }

        if(State == AIStates.Idle)
        {
            timer += Time.deltaTime;
            if(timer > 1)
            {
                StartMove();
                timer = 0;
                Setdirection = (int)MathExtenions.InvertABS(Setdirection);
            }


        }
    }

    protected void StartChase()
    {
        if(State != AIStates.Chasing)
        {
            Debug.Log("DDD");
            StartMove();
            State = AIStates.Chasing;
        }
    }

}
