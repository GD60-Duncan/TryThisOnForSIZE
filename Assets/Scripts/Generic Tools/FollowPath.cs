using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] private Transform[] points;

    [SerializeField] private float MoveSpeed;

    private int pointindex = 0;

    private bool _isMoving = true;
    
    void Start()
    {
        transform.position = points[pointindex].transform.position;
    }

    private void Move()
    {
        if(pointindex <= points.Length - 1 && _isMoving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[pointindex].transform.position, MoveSpeed * Time.deltaTime);
            if(transform.position == points[pointindex].transform.position)
            {
                pointindex +=1;
            }
        }
    }

    public void Stop()
    {
        _isMoving = false;
    }

    public void Go()
    {
        _isMoving = true;
    }
}
