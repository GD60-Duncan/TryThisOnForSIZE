using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] private float _time = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAfterTimer", _time);
    }

    private void DestroyAfterTimer()
    {
        Destroy(this.gameObject);
    }

    
}
