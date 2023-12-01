using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LightWeightFPS : MonoBehaviour
{
    [SerializeField] private PlayerDebugOptions _options;

    private float fps;

    private float frames;

     void OnEnable()
    {
        StartCoroutine(StartFPSTask());
    }

    void Update()
    {
        frames++;
        //Debug.Log(frames);
        //Debug.Log(frames);
        
    }
    

    private IEnumerator StartFPSTask()
    {
        ResetFrameRate();
        yield return new WaitForSeconds(1);
        _options.UpdateFPSText("60 FPS");

        Test();
        

    }

    private void ResetFrameRate()
    {
        frames = 0;
    }

    private async void Test()
    {
        await UpdateTest();
        //Task.Run(UpdateTest)
    }

    private async Task UpdateTest()
    {
        await Task.Delay(1000);
        fps = frames;

        _options.UpdateFPSText(fps + " FPS");
        
        ResetFrameRate();
        if(this.gameObject.activeInHierarchy == true && this.enabled)
        {
            Test();
        }
        
    }


}
