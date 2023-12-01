using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class WaitForVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer _video;

    [SerializeField] private UnityEvent _event;

    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Wait()
    {
        yield return new WaitUntil(IsFinnishedPlaying);
        _event.Invoke();
    
    } 

    private bool IsFinnishedPlaying()
    {
        if(_video.isPlaying == true)
        {
            return false;
        }

        else
        {
            return true;
        }
    }
}
