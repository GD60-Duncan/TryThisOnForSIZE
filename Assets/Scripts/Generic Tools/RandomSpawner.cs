using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public SpawnTypes _spawntype;
    public SpawnAmount _spawnAmount;

    [SerializeField] private GameObject[] _spawnableGameObjects;
    [SerializeField] private GameObject __spawnableGameObject;

    [SerializeField] private float _minfreqency;
    [SerializeField] private float _maxfreqency;

    private bool spawned;

    private int _objectAmount;

     public enum SpawnTypes
    {
		SingleObject,
		MultipleObjects,
        
    }

    public enum SpawnAmount
    {
        OneTime,
        Continous,
    }

    void OnEnable()
    {
        if(_spawntype == SpawnTypes.SingleObject)
        {
            StartCoroutine("SpawnSingleObject");
            return;
        }

        if(_spawntype == SpawnTypes.MultipleObjects)
        {
            StartCoroutine(SpawnMultipleObjects());
        }
    }

    private IEnumerator SpawnSingleObject()
    {  
        float rand = Random.Range(_minfreqency, _maxfreqency);
    
            yield return new WaitForSeconds(rand);
            Instantiate(__spawnableGameObject, transform.position, Quaternion.identity);
            if (_spawnAmount == SpawnAmount.Continous)
            {
                StartCoroutine(SpawnSingleObject());
            }
            yield break;
    }

    private IEnumerator SpawnMultipleObjects()
    {
         float rand = Random.Range(_minfreqency, _maxfreqency);
        if (_spawnAmount == SpawnAmount.Continous)
        {
            int randInt = Random.Range(0, _spawnableGameObjects.Length);
            yield return new WaitForSeconds(rand);
            Instantiate(_spawnableGameObjects[randInt], transform.position, Quaternion.identity);
            if (_spawnAmount == SpawnAmount.Continous)
            {
                StartCoroutine(SpawnMultipleObjects());
            }
            yield break;


        }
    }


}
