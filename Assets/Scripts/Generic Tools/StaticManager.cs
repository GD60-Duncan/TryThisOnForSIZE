﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticManager : MonoBehaviour
{
    virtual protected void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
