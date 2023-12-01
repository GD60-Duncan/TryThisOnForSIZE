using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrackManager : StaticManager
{
    [SerializeField] private AudioSource[] _audioSouces;

    private int audiosourceToUnmute;
}
