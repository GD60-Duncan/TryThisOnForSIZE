using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GenericCharacterSounds : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _characterMix;

    [SerializeField] private AudioMixerGroup _soundEffect;

    [SerializeField] private AudioMixerGroup _importaint;

    [SerializeField] private SoundData _punch;

    [SerializeField] private SoundData _footstep;

    [SerializeField] private AudioClip _characterLand;

    [SerializeField] private AudioClip _jump;

    [SerializeField] private AudioClip _deathNoise;

    [SerializeField] private AudioClip _recharageNiose;

    [SerializeField] private AudioClip _hitstunNoise;

    [SerializeField] private SpriteRenderer _renderer;

    private AudioManager _audioManager;

    private SoundObjectControl resentSound;

    void Start()
    {
        _audioManager = AudioManager.instance; 
    }

    public void Attack()
    {
        _audioManager.PlaySound(this.gameObject.transform.position, _punch);
    }

    public void CharacterLand()
    {
        //_soundeffectManager.PlaySFX(_characterLand,0.4f,_soundEffect,120);
    }

    public void GenericSlash()
    {
        //_soundeffectManager.PlaySFX(_genricSlash, 0.7f, _characterMix, 80);
    }

    public void Jump()
    {
        //_soundeffectManager.PlaySFX(_jump,0.55f, _characterMix, 60);
    }

    public void DeathSound()
    {
        //_soundeffectManager.PlaySFX(_deathNoise,0.7f, _importaint,1);
    }

    public void HitstunSound()
    {
        //_soundeffectManager.PlaySFX(_hitstunNoise,0.6f, _importaint, 80);
    }

    public void Footstep()
    {
        if(_renderer.isVisible == false)
        return;
        //_soundeffectManager.PlaySFX(_footstep,0.5f, _characterMix,133);
    }

    public void RandomizeSound(SoundData[] sounds)
    {
        var e = Random.Range(0, sounds.Length);

        _audioManager.PlaySound(this.gameObject.transform.position, sounds[e]);
    }

    public void GeneralSound(SoundData sound)
    {
        resentSound = _audioManager.PlaySound(this.gameObject.transform.position, sound);
    }

    public void StopRecentSound()
    {
        resentSound.StopAudio();
    }
}
