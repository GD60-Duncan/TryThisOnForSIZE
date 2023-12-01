using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private UnityEvent[] conditions;

    [SerializeField] private Texture2D _mouseLoad;

    [SerializeField] protected bool _reuseableObj;

    protected bool _loadingScene;
    
    private int scene;

    private bool sceneisloaded;

    private bool readyToStart;

    private int condition;
    
    public void Load(int sceneIndex)
    {
        if(_loadingScene) {return;}
        Cursor.SetCursor(_mouseLoad, Vector2.zero, CursorMode.ForceSoftware);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        StartCoroutine(LoadSafety(operation));
    }

    public void AddLoad(int sceneIndex)
    {
        Debug.Log("Add Load");
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
    }

    public void Unload(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.UnloadSceneAsync(sceneIndex);
    }

    public async void LoadWithCondition(int sceneIndex)
    {
        condition = 0;
        Cursor.SetCursor(_mouseLoad, Vector2.zero, CursorMode.ForceSoftware);
        await AwaitCondition();
        
    }

    public async void ReloadWithCondition()
    {
        condition = 1;
        Cursor.SetCursor(_mouseLoad, Vector2.zero, CursorMode.ForceSoftware);
        await AwaitCondition();
    }

    public void ReloadCurrentScene()
    {
        Cursor.SetCursor(_mouseLoad, Vector2.zero, CursorMode.ForceSoftware);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    
    }

    public void MeetCondition()
    {
        readyToStart = true;
    }

    private async Task AwaitCondition()
     {

         
         var tasks = new Task[2];
        
        

        tasks[0] = InvokeEvent(condition);

        await WaitForTask(tasks[0]);

        tasks[1] = SceneAsyncTask();

        //await Task.WhenAll(tasks);

          //GameData.Intitalized = true;

          Debug.Log("MegaBased");
     }

     async Task<bool> WaitForTask(Task t)
     {
        await Task.WhenAll(t);
        //_image.fillAmount = 0;


         
        return true;
     }

     async Task SceneAsyncTask()
     {

        int test = SceneManager.GetActiveScene().buildIndex * condition;
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(test);
        
        
       // AsyncOperation operation = SceneManager.LoadSceneAsync(0);

        operation.allowSceneActivation = false;
        
        while(operation.isDone == false)
        {
            operation.allowSceneActivation = readyToStart;

            Debug.Log(operation.progress);

            await Task.Yield();
        }

         Time.timeScale = 1;
     }

     async Task InvokeEvent(int i)
     {
        await Task.Delay(20);
        conditions[i].Invoke();
       Debug.Log(condition);
     }

    IEnumerator LoadSafety(AsyncOperation operation)
    {
        _loadingScene = true;
        //Time.timeScale = 1;
        while(operation.isDone == false)
        {
            if(Time.timeScale != 1)
            {
                Time.timeScale = 1;
            }
            Debug.Log(operation.progress);
            yield return null;
        }

        _loadingScene = false;

    }
}

