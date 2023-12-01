using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayAudioClip : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private AudioSource _audioSourse;

    [SerializeField] private AudioClip[] _audio;

    public void PlayAudio(AudioClip audio)
    {
        _audioSourse.clip = audio;
        _audioSourse.Play();
    }

    public void PlayAudioArray(int selection)
    {
        _audioSourse.clip = _audio[selection];
        _audioSourse.Play();
    }
}
