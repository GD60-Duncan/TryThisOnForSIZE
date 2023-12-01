using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public static class AsyncExtention
{
    
    public async static void Await(this Task task)
    {
        //return;
        
        try
        {
            //Debug.Log("First Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            await task;
        }

        catch
        {
            //#if UNITY_EDITOR
            Debug.LogException(task.Exception);
            //#endif
            
        }
        
        
    }

    public async static void Pause(this Task task, CancellationTokenSource cancellationTokenSource)
    {
        //if(task.AsyncState == )
        
        Debug.Log(task.AsyncState);

        task.Wait();
        
        
        
    }

    public async static void TimeScaleDelayTask(this Task task, TimeSpan timeSpan, CancellationToken cancellationToken)
    {
        var elapsed = 0f;
        var seconds = timeSpan.Seconds;

        //timeSpan.S

        try
        {
            while (elapsed < seconds)
            {
                elapsed += Time.deltaTime;

                try
                {
                    await Task.Delay(1, cancellationToken);
                }

                catch
                {
                    Debug.LogWarning("Delay Cancel");
                }
                
            }

            await task;
        }

        catch
        {
            Debug.LogException(task.Exception);
        }


    }

    public static async Task TimeScaleDelay(TimeSpan timeSpan, CancellationToken cancellationToken)
    {
        var elapsed = 0f;
        var seconds = timeSpan.TotalSeconds;



        Debug.Log(timeSpan.Milliseconds);

        //timeSpan.S

        try
        {
            while (elapsed < seconds)
            {
                elapsed += Time.deltaTime;

                try
                {
                   await Task.Delay(1, cancellationToken);

                   //return task;
                    
                }

               catch
                {
                    Debug.LogWarning("Delay Cancel");
                    return;
                }
                
            }

        }

        catch
        {
            //Debug.LogException(task.Exception);
            //return task;
        }

        return;
    }

    
}
