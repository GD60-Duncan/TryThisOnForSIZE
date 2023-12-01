using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Threading.Tasks;


public class SoundObjectControl : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField] private AudioSource _audioSource;

    public bool AudioIsPlaying;

    public bool ReservedForMusic;
    public int Priority {get; private set;}
    public float Volume {get; private set;}
    void Start()
    {
        audioManager = AudioManager.instance;
        AudioManager.activeSoundObjects++;

        if(ReservedForMusic)
        {
            audioManager.musicSound = this;
        }
    }

    void OnDestroy()
    {
        AudioManager.activeSoundObjects--;
    }

    public void Audio()
    {
        
        if(_audioSource.isPlaying)
        {
            AudioIsPlaying = true;
            Volume = _audioSource.volume;

            return;
        }
        AudioIsPlaying = false;
    }

    public void PlaySound2D(AudioClip audioClip, float volume, int priority)
    {
        _audioSource.clip = audioClip;
        _audioSource.spatialBlend = 0;
        _audioSource.volume = volume;
        _audioSource.priority = priority;
        _audioSource.Play();
    }

    public void PlaySound3D(AudioClip audioClip, float volume, int priority, Vector3 location)
    {
        _audioSource.clip = audioClip;
        _audioSource.spatialBlend = 1;
        _audioSource.volume = volume;
        transform.position = location;
        _audioSource.priority = priority;
        _audioSource.Play();
    }

    public void StopAudio()
    {
        _audioSource.Stop();
        //_audioSource.Pause();
        AudioIsPlaying = false;
    }

    
}
