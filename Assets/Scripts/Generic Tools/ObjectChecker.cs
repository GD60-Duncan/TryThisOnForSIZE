using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectChecker : MonoBehaviour
{
    [SerializeField] private float _secondInterval;

    [SerializeField] private float _randMin; 
    
    [SerializeField] private float _randMax;

    [SerializeField] private GameObject _object;

    [SerializeField] private CheckAmount _checkAmount;

    [SerializeField] private CheckType _checkType;

    [SerializeField] private UnityEvent _onCheck;

    public bool FalseORTrueCheck;

    protected bool DirectCheck;

    [Header("Only use if it you it is a direct check")] 

    [SerializeField] private Movement _characterMovement;

    [SerializeField] private ObjectManger _typeOfObject;

    [SerializeField] private Renderer _renderer; 

    protected enum CheckAmount
    {
        SecondInterval,
        RandomInterval,

        OnlyOnStart,

    }

    protected enum CheckType
    {
        IsNull,
        CanMove,
        IsDestructalble,
        IsVisible

    }
    void Start()
    {
        if(_object == null)
        {
            DirectCheck = true;
        }
        if(_checkAmount == CheckAmount.OnlyOnStart)
        {
            Check();
            return;
        }
        StartCoroutine(CheckRoutine());
    }

    private IEnumerator CheckRoutine()
    {
        if(_checkAmount == CheckAmount.SecondInterval)
        {
            yield return new WaitForSeconds(_secondInterval);
            Check();
            StartCoroutine(CheckRoutine());
            yield break;
        }

        if(_checkAmount == CheckAmount.RandomInterval)
        {
            float amount = Random.Range(_randMin,_randMax);
            yield return new WaitForSeconds(amount);
            Check();
            StartCoroutine(CheckRoutine());
            yield break;
        }
    }

    public virtual void Check()
    {
        switch (_checkType)
        {
            case CheckType.IsNull:

            if(_object == null)
            {
                _onCheck.Invoke();
            }
            break;

            case CheckType.CanMove:
            if(DirectCheck == false)
            {
                _characterMovement = _object?.GetComponent<Movement>();
            }
            if(_characterMovement.CanMove == FalseORTrueCheck)
            {
                _onCheck.Invoke();
            } 
            break;

            case CheckType.IsDestructalble:
            _typeOfObject = _object?.GetComponent<ObjectManger>(); //don't use
            {

            }
            break;

            case CheckType.IsVisible:
            if(DirectCheck == false)
            {
                _renderer = _object?.GetComponent<Renderer>();
            }
            if(_renderer.isVisible == FalseORTrueCheck)
            {
                _onCheck.Invoke();
            }
            break;
        }
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    
}
