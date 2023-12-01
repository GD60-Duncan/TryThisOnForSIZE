using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    void Awake()
    {
        GameData.ActiveCamera = _camera;
    }
}
