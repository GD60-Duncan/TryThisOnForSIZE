using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyWeightFPS : MonoBehaviour
{
   [SerializeField] private PlayerDebugOptions _options;

   private float timeCounter = 0.0f;

   private float refreshTime = 0.1f;

   private float maxframerate = 0f;
   private float minframerate = 1000f;

   private int frames;
    void Update()
    {
        
        if(timeCounter < refreshTime)
        {
            timeCounter += Time.unscaledDeltaTime;
            frames++;
            return;
        }

        float lastframe = frames / timeCounter;
        if(minframerate > lastframe)
        {minframerate = lastframe;}

        if(maxframerate < lastframe)
        {maxframerate = lastframe;}
        float ms = 1000.0f / Mathf.Max(lastframe, 0.00001f);
        frames = 0;
        timeCounter = 0.0f;
        _options.UpdateFPSText(lastframe.ToString("n1") + " FPS " + ms.ToString("n1") + " ms");
        
    }
}
